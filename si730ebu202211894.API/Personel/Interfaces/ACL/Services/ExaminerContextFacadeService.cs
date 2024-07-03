
using si730ebu202211894.API.Personel.Domain.Model.Queries;
using si730ebu202211894.API.Personel.Domain.Services;

namespace si730ebu202211894.API.Personel.Interfaces.ACL.Services;

public class ExaminerContextFacadeService(IExaminerQueryService examinerQueryService): IExaminerContextFacade
{
    
    public async Task<bool> GetNationalProviderIdentifier(string nationalProviderIdentifier)
    {
        var getNationalProviderIdentifier = new GetNationalProviderIdentifier(nationalProviderIdentifier);
        var npi = await examinerQueryService.Handle(getNationalProviderIdentifier);

        if (npi?.NationalProviderIdentifier == null)
        {
            throw new Exception("This National Provider Identifier does not exist.");
        }

        return true;
    }
    
}