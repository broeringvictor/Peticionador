namespace Infrastructure.Data.Identity.UseCases;

public interface IUserRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
    Task SaveAsync(User user, string password, CancellationToken cancellationToken);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken); // Modificado para retornar User?
}