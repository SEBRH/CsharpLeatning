using si730ebu202211894.API.Personel.Domain.Model.Aggregate;
using si730ebu202211894.API.Personel.Domain.Model.Queries;

namespace si730ebu202211894.API.Personel.Domain.Services;

public interface IExaminerQueryService
{
    Task<Examiner?> Handle(GetNationalProviderIdentifier query);
}