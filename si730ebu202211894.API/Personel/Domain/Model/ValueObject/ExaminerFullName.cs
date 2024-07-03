namespace si730ebu202211894.API.Personel.Domain.Model.ValueObject;

public record ExaminerFullName(string FirstName, string LastName)
{
    public ExaminerFullName() : this(string.Empty, string.Empty)
    {
    }
    
    public ExaminerFullName(string firstName) : this(firstName, string.Empty)
    {
        FirstName = firstName;
        LastName = "Not Provided";
    }
    
    public string FullName => $"{FirstName} {LastName}";
    
}