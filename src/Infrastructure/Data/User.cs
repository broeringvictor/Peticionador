using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data;

public sealed class User : IdentityUser
{
    [Required(ErrorMessage = "[UsERO1] O campo Nome Completo é obrigatório")]
    [StringLength(100, MinimumLength = 8,
        ErrorMessage = "[UsERO2] O campo Nome Completo deve ter entre 8 e 100 caracteres")]
    public string? Name { get; set; }

    public User(string email, string name) : base()
    {
        if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            throw new ArgumentException("[UsERO3] O campo E-mail é inválido.", nameof(email));

        if (string.IsNullOrEmpty(name) || name.Length < 8)
            throw new ArgumentException("[UsERO4] O nome deve conter pelo menos 8 caracteres.", nameof(name));

        Email = email;
        Name = name;
        UserName = email; // Identity usa UserName como login, geralmente o mesmo que o email.
    }
}