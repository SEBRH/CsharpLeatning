using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebu202211894.API.Assessment.Domain.Model.Aggregate;
using si730ebu202211894.API.Patients.Domain.Model.Aggregate;
using si730ebu202211894.API.Personel.Domain.Model.Aggregate;
using si730ebu202211894.API.Personel.Domain.Model.Entities;
using si730ebu202211894.API.Personel.Domain.Model.ValueObject;

namespace si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {        
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<ExaminerType>().HasData(
            Enum.GetValues(typeof(EExaminerType))
                .Cast<EExaminerType>()
                .Select((e, index) => new ExaminerType { Id = index + 1, Name = e.ToString() })
        );
        // Examiner Context
        builder.Entity<Examiner>().HasKey(c => c.Id);
        builder.Entity<Examiner>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Examiner>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });
        builder.Entity<Examiner>().Property(c => c.NationalProviderIdentifier).IsRequired().HasMaxLength(50);
        
        // Examiner Relationships
        builder.Entity<Examiner>()
            .HasOne(r => r.ExaminerType)
            .WithMany()
            .HasForeignKey(r => r.ExaminerTypeId)
            .HasPrincipalKey(r => r.Id);
        
        // Patient Context
        builder.Entity<Patient>().HasKey(c => c.Id);
        builder.Entity<Patient>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Patient>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });
        
        
        // MentalStateExam Context
        builder.Entity<MentalStateExam>().HasKey(c => c.Id);
        builder.Entity<MentalStateExam>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MentalStateExam>().Property(c => c.NationalProviderIdentifier).IsRequired().HasMaxLength(50);
        builder.Entity<MentalStateExam>().Property(c => c.ExamDate).IsRequired();
        builder.Entity<MentalStateExam>().Property(c => c.LanguageScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(c => c.RecallScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(c => c.OrientationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(c => c.AttentionAndCalculationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(c => c.RegistrationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(c => c.PatientId).IsRequired();
      
        
     
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}