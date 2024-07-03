using si730ebu202211894.API.Personel.Interfaces.ACL;

namespace si730ebu202211894.API.Assessment.Application.Internal.OutboundServices.ACL;

public class ExternalExaminerService(IExaminerContextFacade examinerContextFacade)
{

    public async Task<bool> GetNationalProviderIdentifier(string nationalProviderIdentifier)
    {
        var npi = await examinerContextFacade.GetNationalProviderIdentifier(nationalProviderIdentifier);
        return npi;
    }
    
    
}