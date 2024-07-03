using System.Runtime.InteropServices.JavaScript;

namespace si730ebu202211894.API.Assessment.Domain.Model.Command;

public record CreateMentalStateExamCommand(
    int PatientId,
    string NationalProviderIdentifier,
    DateOnly ExamDate,
    int OrientationScore,
    int RegistrationScore,
    int AttentionAndCalculationScore,
    int RecallScore,
    int LanguageScore
    );