
using si730ebu202211894.API.Personel.Domain.Model.Aggregate;
using si730ebu202211894.API.Personel.Domain.Model.Command;
using si730ebu202211894.API.Personel.Domain.Repositories;
using si730ebu202211894.API.Personel.Domain.Services;
using si730ebu202211894.API.Shared.Domain.Repositories;

namespace si730ebu202211894.API.Personel.Application.Internal.CommandService;

public class ExaminerCommandServiceImpl(IExaminerRepository examinerRepository, IUnitOfWork unitOfWork, IExaminerTypeRepository examinerTypeRepository): IExaminerCommandService
{
    public async Task<Examiner?> Handle(CreateExaminerCommand command)
    {
        
        if (examinerRepository.ExistsByNationalProviderIdentifierAsync(command.NationalProviderIdentifier))
        {
            throw new Exception("This examiner already exists.");
        }

        if (await examinerTypeRepository.ExistExaminerTypeById(command.ExaminerTypeId) == false)
        {
            throw new Exception("Not a valid examiner Type.");
        }
        
        var examinerType = await examinerTypeRepository.GetByIdAsync(command.ExaminerTypeId);
        
        var examiner = new Examiner(command)
        {
            ExaminerType = examinerType
        };
        try{
            await examinerRepository.AddAsync(examiner);
            await unitOfWork.CompleteAsync();
            return examiner;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating a reservation: {e.Message}");
            throw new Exception("An error occurred while creating a reservation");
        }
        
    }
}