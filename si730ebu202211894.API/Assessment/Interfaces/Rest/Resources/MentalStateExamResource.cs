using System.Runtime.InteropServices.JavaScript;

namespace si730ebu202211894.API.Assessment.Interfaces.Rest.Resources;
public record MentalStateExamResource(int Id,int PatientId,
    string NationalProviderIdentifier,
    DateOnly ExamDate,
    int OrientationScore,
    int RegistrationScore,
    int AttentionAndCalculationScore,
    int RecallScore,
    int LanguageScore);