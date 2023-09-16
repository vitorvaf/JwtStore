
using JwtStore.Core;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Api.Extension;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

        Configuration.Secrets.ApiKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("ApiKey") ?? string.Empty;
        Configuration.Secrets.JwtPrivateKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("JwtPrivateKey") ?? string.Empty;
        Configuration.Secrets.PasswordSaltKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("PasswordSaltKey") ?? string.Empty;

        Configuration.SendGrid.ApiKey =
            builder.Configuration.GetSection("SendGrid").GetValue<string>("ApiKey") ?? string.Empty;

        Configuration.Email.DefaultFromName =
            builder.Configuration.GetSection("Email").GetValue<string>("DefaultFromName") ?? string.Empty;
        Configuration.Email.DefaultFromEmail =
            builder.Configuration.GetSection("Email").GetValue<string>("DefaultFromEmail") ?? string.Empty;
    }

    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x =>
            x.UseSqlServer(
                Configuration.Database.ConnectionString,
                b => b.MigrationsAssembly("JwtStore.Api")));
    }
}
