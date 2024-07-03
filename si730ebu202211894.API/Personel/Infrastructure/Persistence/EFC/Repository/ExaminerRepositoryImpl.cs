using Microsoft.EntityFrameworkCore;
using si730ebu202211894.API.Personel.Domain.Model.Aggregate;
using si730ebu202211894.API.Personel.Domain.Repositories;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202211894.API.Personel.Infrastructure.Persistence.EFC.Repository;

public class ExaminerRepositoryImpl(AppDbContext context): BaseRepository<Examiner>(context), IExaminerRepository
{
    public bool ExistsByNationalProviderIdentifierAsync(string nationalProviderIdentifier)
    {
        return context.Set<Examiner>().Any(x => x.NationalProviderIdentifier == nationalProviderIdentifier);
        
    }
    
    public async Task<Examiner?> GetByNationalProviderIdentifierAsync(string nationalProviderIdentifier)
    {
        return await context.Set<Examiner>().FirstOrDefaultAsync(x => x.NationalProviderIdentifier == nationalProviderIdentifier);
    }
    
}