using Domain;
using Infrastructure.Data;
using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
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
        // Configuração de DbContext e Identity
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                Configurations.Database.ConnectionString,
                b => b.MigrationsAssembly("WebApi")));

        builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("DefaultPolicy", policy =>
            {
                policy.RequireAuthenticatedUser();
            });
        });
    }








}