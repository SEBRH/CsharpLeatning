using si730ebu202211894.API.Personel.Domain.Model.Aggregate;
using si730ebu202211894.API.Shared.Domain.Repositories;

namespace si730ebu202211894.API.Personel.Domain.Repositories;

public interface IExaminerRepository : IBaseRepository<Examiner>
{
    bool ExistsByNationalProviderIdentifierAsync(string nationalProviderIdentifier);
    
    Task<Examiner?> GetByNationalProviderIdentifierAsync(string nationalProviderIdentifier);
    
}