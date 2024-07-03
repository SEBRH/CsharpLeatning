namespace si730ebu202211894.API.Personel.Domain.Model.Command;

public record CreateExaminerCommand(
    string FirstName,
    string LastName,
    string NationalProviderIdentifier,
    int ExaminerTypeId
    );