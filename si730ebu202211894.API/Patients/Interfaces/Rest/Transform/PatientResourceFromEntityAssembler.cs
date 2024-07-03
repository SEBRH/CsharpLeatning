using si730ebu202211894.API.Patients.Domain.Model.Aggregate;
using si730ebu202211894.API.Patients.Interfaces.Rest.Resource;

namespace si730ebu202211894.API.Patients.Interfaces.Rest.Transform;

public class PatientResourceFromEntityAssembler
{
    public static PatientResource ToResourceFromEntity(Patient entity)
    {
        return new PatientResource(entity.Id, entity.FullName);
    } 
    
}