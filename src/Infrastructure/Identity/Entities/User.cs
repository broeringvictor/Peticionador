using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Entities;

public class User : IdentityUser
{
    [Required(ErrorMessage = "[UsERO1] O campo Nome Completo é obrigatório")]
    [Length(8, 100, ErrorMessage = "[UsERO2] O campo Nome Completo deve ter entre 8 e 100 caracteres")]
    public string Name { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "[UsERO3] Email inválido.")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; }

}