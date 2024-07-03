namespace si730ebu202211894.API.Patients.Domain.Model.Command;

public record CreatePatientCommand(
    
    string FirstName,
    string LastName
    
    );