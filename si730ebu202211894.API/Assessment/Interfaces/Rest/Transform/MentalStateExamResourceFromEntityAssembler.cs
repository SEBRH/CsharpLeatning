using si730ebu202211894.API.Assessment.Domain.Model.Aggregate;
using si730ebu202211894.API.Assessment.Interfaces.Rest.Resources;

namespace si730ebu202211894.API.Assessment.Interfaces.Rest.Transform;

public class MentalStateExamResourceFromEntityAssembler
{
    public static MentalStateExamResource ToResourceFromEntity(MentalStateExam entity)
    {
        return new MentalStateExamResource(entity.Id, entity.PatientId, entity.NationalProviderIdentifier, entity.ExamDate, entity.OrientationScore, entity.RegistrationScore, entity.AttentionAndCalculationScore, entity.RecallScore, entity.LanguageScore);
    } 
}