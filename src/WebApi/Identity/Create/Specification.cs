using Flunt.Notifications;
using Flunt.Validations;

namespace WebApi.Identity.Create;

public static class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Name.Length, 160, "Name", "O nome deve conter menos que 160 caracteres")
            .IsGreaterThan(request.Name.Length, 3, "Name", "O nome deve conter mais que 3 caracteres")
            .IsEmail(request.Email, "Email", "E-mail inválido"); // Validação básica do formato do e-mail.
}