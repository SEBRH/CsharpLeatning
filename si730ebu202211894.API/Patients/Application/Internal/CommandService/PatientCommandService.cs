using si730ebu202211894.API.Patients.Domain.Model.Aggregate;
using si730ebu202211894.API.Patients.Domain.Model.Command;
using si730ebu202211894.API.Patients.Domain.Repositories;
using si730ebu202211894.API.Patients.Domain.Services;
using si730ebu202211894.API.Shared.Domain.Repositories;

namespace si730ebu202211894.API.Patients.Application.Internal.CommandService;

public class PatientCommandService(IPatientRepository patientRepository, IUnitOfWork unitOfWork): IPatientCommandService
{
    public async Task<Patient> Handle(CreatePatientCommand command)
    {
        if(command.FirstName == null || command.LastName == null || command.FirstName == "" || command.LastName == "")
        {
            throw new Exception("First name and last name are required.");
        }
        
        var patient = new Patient(command);
        
        try
        {
            await patientRepository.AddAsync(patient);
            await unitOfWork.CompleteAsync();
            return patient;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }
    }
}