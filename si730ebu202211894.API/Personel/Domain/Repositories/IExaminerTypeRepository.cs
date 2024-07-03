using si730ebu202211894.API.Personel.Domain.Model.Entities;
using si730ebu202211894.API.Shared.Domain.Repositories;

namespace si730ebu202211894.API.Personel.Domain.Repositories;

public interface IExaminerTypeRepository : IBaseRepository<ExaminerType>
{
    Task<bool> ExistExaminerTypeById(int examinerTypeId);
    Task<ExaminerType?> GetByIdAsync(int examinerTypeId);
}