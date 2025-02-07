using Infrastructure.Data.Identity.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/users")]
public class IdentityUserController(CreateUserUseCase createUserUseCase) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Request request, CancellationToken cancellationToken)
    {
        try
        {
            await createUserUseCase.Execute(request.Email, request.Name, request.Password, cancellationToken);
            return Ok("Usuário criado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}

