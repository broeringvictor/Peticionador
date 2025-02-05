using Infrastructure.Data.Identity.UseCases;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace WebApi.Api;

public static class IdentityApi
{
    #region Create Services

    public static void AddIdentityApiBuilderService(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IRepository, Identity.Repository>();
    }

    #endregion
    public static IEndpointRouteBuilder MapCatalogApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/identity").HasApiVersion(1.0);
        api.MapPost("/", Create)
            .WithName("CreateUser")
            .WithSummary("Create a User")
            .WithDescription("Create a new User in the Project");

        return app;
    }

    private static Task Create(HttpContext context)
    {
        throw new NotImplementedException();
    }
}