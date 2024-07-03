using si730ebu202211894.API.Assessment.Domain.Model.Command;
using si730ebu202211894.API.Assessment.Interfaces.Rest.Resources;

namespace si730ebu202211894.API.Assessment.Interfaces.Rest.Transform;

public class CreateMentalStateExamCommandFromResourceAssembler
{
    public static CreateMentalStateExamCommand ToCommandFromResourceAssembler(CreateMentalStateExamResource resource)
    {
        return new CreateMentalStateExamCommand(resource.PatientId,
            resource.NationalProviderIdentifier,
            DateOnly.Parse(resource.ExamDate),
            resource.OrientationScore,
            resource.RegistrationScore,
            resource.AttentionAndCalculationScore,
            resource.RecallScore,
            resource.LanguageScore);
    }
}