namespace si730ebu202211894.API.Personel.Interfaces.ACL;

public interface IExaminerContextFacade
{
    Task<bool> GetNationalProviderIdentifier(string nationalProviderIdentifier);
    
}