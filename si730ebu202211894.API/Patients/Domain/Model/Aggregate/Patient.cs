using si730ebu202211894.API.Patients.Domain.Model.Command;
using si730ebu202211894.API.Patients.Domain.Model.ValueObject;

namespace si730ebu202211894.API.Patients.Domain.Model.Aggregate;

public partial class Patient
{
    public int Id  { get; set; }
    public PatientFullName Name { get; set; }
    
    public string FullName => Name.FullName;
    
    public Patient()
    {
        Name = new PatientFullName();
    }
    
    public Patient(CreatePatientCommand command)
    {
        
        Name = new PatientFullName(command.FirstName, command.LastName);
        
    }
    
}