using Infrastructure.Identity.Entities;

namespace Infrastructure.Data.Identity.UseCases;

public interface IRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
    Task SaveAsync(User user, CancellationToken cancellationToken);
    
}