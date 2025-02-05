using Flunt.Notifications;
using Infrastructure.Data.Identity.UseCases;
using Infrastructure.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WebApi.Identity.Create;

namespace WebApi.Identity.Create;

public class Handler(UserManager<User> userManager, IRepository repository) : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository = repository;
    public async Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {


        #region 01. Valida a requisição

        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
                return new Response("Requisição inválida", 400, res.Notifications);
        }
        catch
        {
            return new Response("Não foi possível validar sua requisição", 500);
        }

        #endregion

        #region 02. Verifica se o usuário existe no banco

        try
        {
            var exists = await _repository.AnyAsync(request.Email, cancellationToken);
            if (exists)
                return new Response("Este E-mail já está em uso", 400);
        }
        catch
        {
            return new Response("Falha ao verificar E-mail cadastrado", 500);
        }

        #endregion

        #region 03. Criar o usuário usando o Identity

        User user;

        try
        {
            // Cria uma instância do usuário conforme entidade do Identity
            user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name
            };

            // Usa o UserManager para criar o usuário com hashing
            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return new Response(
                    "Erro ao criar o usuário",
                    400,
                    result.Errors.Select(e => new Notification(e.Code, e.Description))); // Retorna os erros detalhados
        }
        catch (Exception ex)
        {
            return new Response($"Erro ao criar o usuário: {ex.Message}", 500);
        }

        #endregion

        #region 03. Resposta de sucesso

        return new Response(
            "Conta criada com sucesso",
            new ResponseData(user.Id, user.Name, user.Email));

        #endregion
    }
}