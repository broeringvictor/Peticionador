using MediatR;

namespace WebApi.Identity.Create;

public abstract record Request(
    string Name,
    string Email,
    string Password
) : IRequest<Response>;