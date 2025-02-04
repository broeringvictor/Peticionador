using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.AddConnections();
        builder.AddDatabase();
    }

    private static void AddConnections(this WebApplicationBuilder builder)
    {
        Configurations.Database.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    private static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x =>
            x.UseSqlServer(
                Configurations.Database.ConnectionString,
                b => b.MigrationsAssembly("WebApi")));
    }



}