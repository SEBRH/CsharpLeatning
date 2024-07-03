using si730ebu202211894.API.Personel.Domain.Model.Aggregate;
using si730ebu202211894.API.Personel.Domain.Model.Command;

namespace si730ebu202211894.API.Personel.Domain.Services;

public interface IExaminerCommandService
{
    Task<Examiner?> Handle(CreateExaminerCommand command);
}