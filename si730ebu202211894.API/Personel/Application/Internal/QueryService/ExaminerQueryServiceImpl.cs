using si730ebu202211894.API.Personel.Domain.Model.Aggregate;
using si730ebu202211894.API.Personel.Domain.Model.Queries;
using si730ebu202211894.API.Personel.Domain.Repositories;
using si730ebu202211894.API.Personel.Domain.Services;

namespace si730ebu202211894.API.Personel.Application.Internal.QueryService;

public class ExaminerQueryServiceImpl(IExaminerRepository examinerRepository) : IExaminerQueryService
{
    
    
    public Task<Examiner?> Handle(GetNationalProviderIdentifier query)
    {
        var npiExist =  examinerRepository.ExistsByNationalProviderIdentifierAsync(query.NationalProviderIdentifier);
        if (npiExist)
        {
            return examinerRepository.GetByNationalProviderIdentifierAsync(query.NationalProviderIdentifier);
        }
        throw new Exception("This National Provider Identifier does not exist.");
    }
    
}