using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Identity.UseCases
{
    public class UserRepository(UserManager<User> userManager) : IUserRepository
    {
        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
        => await userManager.FindByEmailAsync(email) != null;


        public async Task SaveAsync(User user, string password, CancellationToken cancellationToken)
        {
            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                // Combine os erros no Exception.
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Não foi possível criar o usuário: {errors}");
            }
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        => await userManager.FindByEmailAsync(email);

    }

}