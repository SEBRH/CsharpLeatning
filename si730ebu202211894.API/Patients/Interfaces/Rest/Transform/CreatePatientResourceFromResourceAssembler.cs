using si730ebu202211894.API.Patients.Domain.Model.Command;
using si730ebu202211894.API.Patients.Interfaces.Rest.Resource;

namespace si730ebu202211894.API.Patients.Interfaces.Rest.Transform;

public class CreatePatientResourceFromResourceAssembler
{
    public static CreatePatientCommand ToCommandFromResource(CreatePatientResource resource)
    {
        return new CreatePatientCommand(resource.FirstName, resource.LastName);
    }
}