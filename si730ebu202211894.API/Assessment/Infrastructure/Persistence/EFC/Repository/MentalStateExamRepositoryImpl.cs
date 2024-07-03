using Microsoft.EntityFrameworkCore;
using si730ebu202211894.API.Assessment.Domain.Model.Aggregate;
using si730ebu202211894.API.Assessment.Domain.Repositories;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202211894.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202211894.API.Assessment.Infrastructure.Persistence.EFC.Repository;

public class MentalStateExamRepositoryImpl(AppDbContext context): BaseRepository<MentalStateExam>(context), IMentalStateExamRepository
{
    public async Task<MentalStateExam?> GetByIdAsync(int id)
    {
        return await context.Set<MentalStateExam>().FirstOrDefaultAsync(x => x.Id == id);
    }
}