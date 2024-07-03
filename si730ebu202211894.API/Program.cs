using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebu202211894.API.Assessment.Application.Internal.CommandService;
using si730ebu202211894.API.Assessment.Application.Internal.OutboundServices.ACL;
using si730ebu202211894.API.Assessment.Domain.Repositories;
using si730ebu202211894.API.Assessment.Domain.Services;
using si730ebu202211894.API.Assessment.Infrastructure.Persistence.EFC.Repository;
using si730ebu202211894.API.Patients.Application.Internal.CommandService;
using si730ebu202211894.API.Patients.Domain.Repositories;
using si730ebu202211894.API.Patients.Domain.Services;
using si730ebu202211894.API.Patients.Infrastructure.Persistence.EFC.Repository;
using si730ebu202211894.API.Personel.Application.Internal.CommandService;
using si730ebu202211894.API.Personel.Application.Internal.QueryService;
using si730ebu202211894.API.Personel.Domain.Repositories;
using si730ebu202211894.API.Personel.Domain.Services;
using si730ebu202211894.API.Personel.Infrastructure.Persistence.EFC.Repository;
using si730ebu202211894.API.Personel.Interfaces.ACL;
using si730ebu202211894.API.Personel.Interfaces.ACL.Services;
using si730ebu202211894.API.Shared.Domain.Repositories;
using si730ebu202211894.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "HIGN API",
                Version = "v1",
                Description = "HIGN Platform API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "HIGN Studios",
                    Email = "contactHign@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Personnel Bounded Context Injection Configuration
builder.Services.AddScoped<IExaminerRepository, ExaminerRepositoryImpl>();
builder.Services.AddScoped<IExaminerCommandService, ExaminerCommandServiceImpl>();
builder.Services.AddScoped<IExaminerQueryService, ExaminerQueryServiceImpl>();
builder.Services.AddScoped<IExaminerContextFacade, ExaminerContextFacadeService>();

// Assessment Bounded Context Injection Configuration
builder.Services.AddScoped<IMentalStateExamRepository, MentalStateExamRepositoryImpl>();
builder.Services.AddScoped<IMentalStateExamCommandService, MentalStateExamCommandService>();
builder.Services.AddScoped<ExternalExaminerService>();
builder.Services.AddScoped<IExaminerTypeRepository, ExaminerTypeRepositoryImpl>();
// Patients Bounded Context Injection Configuration
builder.Services.AddScoped<IPatientRepository, PatientRepositoryImpl>();
builder.Services.AddScoped<IPatientCommandService, PatientCommandService>();



var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
