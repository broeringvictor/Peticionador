namespace Infrastructure.Data.Identity.UseCases;

public record Request(

    string Name,
    string Email,
    string Password
);