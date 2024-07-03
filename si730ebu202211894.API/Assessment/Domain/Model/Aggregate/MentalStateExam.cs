using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualBasic;
using si730ebu202211894.API.Assessment.Domain.Model.Command;

namespace si730ebu202211894.API.Assessment.Domain.Model.Aggregate;

public partial class MentalStateExam
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string NationalProviderIdentifier { get; set; }
    public DateOnly ExamDate { get; set; }
    public int OrientationScore { get; set; }
    public int RegistrationScore { get; set; }
    public int AttentionAndCalculationScore { get; set; }
    public int RecallScore { get; set; }
    public int LanguageScore { get; set; }
    
    public MentalStateExam()
    {
        
    }

    public MentalStateExam(CreateMentalStateExamCommand command)
    {
        PatientId = command.PatientId;
        NationalProviderIdentifier = command.NationalProviderIdentifier;
        ExamDate = command.ExamDate;
        OrientationScore = command.OrientationScore;
        RegistrationScore = command.RegistrationScore;
        AttentionAndCalculationScore = command.AttentionAndCalculationScore;
        RecallScore = command.RecallScore;
        LanguageScore = command.LanguageScore;
    }
    
    
}