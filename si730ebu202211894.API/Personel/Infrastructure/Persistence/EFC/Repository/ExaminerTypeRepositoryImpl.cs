using Microsoft.EntityFrameworkCore;
using si730ebu202211894.API.Personel.Domain.Model.Entities;
using si730ebu202211894.API.Personel.Domain.Repositories;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202211894.API.Personel.Infrastructure.Persistence.EFC.Repository;

public class ExaminerTypeRepositoryImpl(AppDbContext context): BaseRepository<ExaminerType>(context), IExaminerTypeRepository  
{
    public async Task<bool> ExistExaminerTypeById(int examinerTypeId)
    {
        return await context.Set<ExaminerType>().AnyAsync(x => x.Id == examinerTypeId);
    }
    
    public async Task<ExaminerType?> GetByIdAsync(int examinerTypeId)
    {
        return await context.Set<ExaminerType>().FirstOrDefaultAsync(x => x.Id == examinerTypeId);
    }
    
}