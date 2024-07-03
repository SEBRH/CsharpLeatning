namespace si730ebu202211894.API.Personel.Interfaces.Rest.Resources;

public record CreateExaminerResource(string FirstName, string LastName, string NationalProviderIdentifier, int ExaminerTypeId);