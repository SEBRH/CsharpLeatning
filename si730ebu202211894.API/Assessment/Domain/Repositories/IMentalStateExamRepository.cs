using si730ebu202211894.API.Assessment.Domain.Model.Aggregate;
using si730ebu202211894.API.Shared.Domain.Repositories;

namespace si730ebu202211894.API.Assessment.Domain.Repositories;

public interface IMentalStateExamRepository : IBaseRepository<MentalStateExam>
{
    Task<MentalStateExam?> GetByIdAsync(int mentalStateExamId);
}