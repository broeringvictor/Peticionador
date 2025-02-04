using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Account;

public class User
{
    [Key]
    public Guid Id { get; set; }

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