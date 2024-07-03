using si730ebu202211894.API.Assessment.Domain.Model.Aggregate;
using si730ebu202211894.API.Patients.Domain.Model.Aggregate;
using si730ebu202211894.API.Shared.Domain.Repositories;

namespace si730ebu202211894.API.Patients.Domain.Repositories;

public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<bool> ExistsByIdAsync(int mentalStateExamId);
    
    
}