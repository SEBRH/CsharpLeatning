using si730ebu202211894.API.Personel.Domain.Model.Aggregate;
using si730ebu202211894.API.Personel.Interfaces.Rest.Resources;

namespace si730ebu202211894.API.Personel.Interfaces.Rest.Transform;

public class ExaminerResourceFromEntityAssembler
{
    public static ExaminerResource ToResourceFromEntity(Examiner entity)
    {
        return new ExaminerResource(entity.Id, entity.FullName, entity.NationalProviderIdentifier, entity.ExaminerTypeName);
    }
}