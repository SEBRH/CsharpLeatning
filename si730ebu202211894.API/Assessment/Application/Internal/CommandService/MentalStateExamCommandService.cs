using si730ebu202211894.API.Assessment.Application.Internal.OutboundServices.ACL;
using si730ebu202211894.API.Assessment.Domain.Model.Aggregate;
using si730ebu202211894.API.Assessment.Domain.Model.Command;
using si730ebu202211894.API.Assessment.Domain.Repositories;
using si730ebu202211894.API.Assessment.Domain.Services;
using si730ebu202211894.API.Shared.Domain.Repositories;

namespace si730ebu202211894.API.Assessment.Application.Internal.CommandService;

public class MentalStateExamCommandService(IMentalStateExamRepository mentalStateExamRepository, ExternalExaminerService externalExaminerService, IUnitOfWork unitOfWork): IMentalStateExamCommandService
{
    
    public async Task<MentalStateExam?> Handle(CreateMentalStateExamCommand command)
    {
      var isValid = await externalExaminerService.GetNationalProviderIdentifier(command.NationalProviderIdentifier);
         if (!isValid) {
            throw new Exception("This National Provider is NotValid not exist."); }

         
         
         try
         {
                var mentalStateExam = new MentalStateExam(command);
                await mentalStateExamRepository.AddAsync(mentalStateExam);
                await unitOfWork.CompleteAsync();
                return mentalStateExam;
                
         }
         catch (Exception e)
         {
             throw new Exception($"An error occurred while creating Mental State Exam: {e.Message}");
         }
         
      
    }
    
}