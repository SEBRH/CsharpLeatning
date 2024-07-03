namespace si730ebu202211894.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}