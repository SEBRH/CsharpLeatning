using Microsoft.EntityFrameworkCore;
using si730ebu202211894.API.Assessment.Domain.Model.Aggregate;
using si730ebu202211894.API.Assessment.Domain.Repositories;
using si730ebu202211894.API.Patients.Domain.Model.Aggregate;
using si730ebu202211894.API.Patients.Domain.Repositories;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202211894.API.Patients.Infrastructure.Persistence.EFC.Repository;

public class PatientRepositoryImpl(AppDbContext context): BaseRepository<Patient>(context), IPatientRepository
{
    public async Task<bool> ExistsByIdAsync(int patientId)
    {
        return await context.Set<Patient>().AnyAsync(x => x.Id == patientId);
    }
    
}