using System.ComponentModel.DataAnnotations;
using Domain.Entities.Account;

namespace Domain.Entities.Tokens;

public class TokensUsage
{
    [Key]
    public required long Id { get; set; }

    public required int ModelUsage { get; set; }

    public int TokenUsage { get; set; }

    public DateTime Date { get; set; }

    public required User UserId { get; set; }

    public int? TokenInput { get; set; }

    public int? TokenOutput { get; set; }


}