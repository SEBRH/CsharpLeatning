using si730ebu202211894.API.Patients.Domain.Model.Aggregate;
using si730ebu202211894.API.Patients.Domain.Model.Command;

namespace si730ebu202211894.API.Patients.Domain.Services;

public interface IPatientCommandService
{
    Task<Patient?> Handle(CreatePatientCommand command);
}