namespace si730ebu202211894.API.Patients.Domain.Model.ValueObject;

public record PatientFullName(string FirstName, string LastName)
{
    public PatientFullName() : this(string.Empty, string.Empty)
    {
    }
    
    public PatientFullName(string firstName) : this(firstName, string.Empty)
    {
        FirstName = firstName;
        LastName = "Not Provided";
    }
    
    public string FullName => $"{FirstName} {LastName}";
    
}