using Domain;
using Infrastructure.Data;
using Infrastructure.Data.Identity.UseCases;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.AddUseCases();
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.AddConnections();
        builder.AddDatabase();
    }

    private static void AddConnections(this WebApplicationBuilder builder)
    {
        Configurations.Database.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    }

    private static void AddUseCases(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<CreateUserUseCase>();

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

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 3; // Apenas para teste!
        });


        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("DefaultPolicy", policy =>
            {
                policy.RequireAuthenticatedUser();
            });
        });
    }








}