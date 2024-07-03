using si730ebu202211894.API.Assessment.Domain.Model.Aggregate;
using si730ebu202211894.API.Assessment.Domain.Model.Command;

namespace si730ebu202211894.API.Assessment.Domain.Services;

public interface IMentalStateExamCommandService
{
    Task<MentalStateExam?> Handle(CreateMentalStateExamCommand command);
}