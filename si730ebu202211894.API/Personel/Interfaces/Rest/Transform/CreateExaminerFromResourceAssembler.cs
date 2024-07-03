using si730ebu202211894.API.Personel.Domain.Model.Command;
using si730ebu202211894.API.Personel.Interfaces.Rest.Resources;

namespace si730ebu202211894.API.Personel.Interfaces.Rest.Transform;

public class CreateExaminerFromResourceAssembler
{
    public static CreateExaminerCommand ToCommandFromResourceAssembler(CreateExaminerResource resource)
    {
        return new CreateExaminerCommand(resource.FirstName, resource.LastName, resource.NationalProviderIdentifier, resource.ExaminerTypeId);
    }
}