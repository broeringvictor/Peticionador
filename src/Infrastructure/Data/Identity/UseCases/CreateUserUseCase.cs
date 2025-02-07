namespace Infrastructure.Data.Identity.UseCases;

public class CreateUserUseCase(IUserRepository userRepository)
{
    public async Task Execute(string email, string name, string password, CancellationToken cancellationToken)
    {
        bool userExists = await userRepository.AnyAsync(email, cancellationToken);

        if (userExists)
            throw new InvalidOperationException("Usuário com este e-mail já existe.");

        var user = new User(email, name); // Criar usuário sem senha.

        // Salvar usuário com senha no repositório.
        await userRepository.SaveAsync(user, password, cancellationToken);
    }
}