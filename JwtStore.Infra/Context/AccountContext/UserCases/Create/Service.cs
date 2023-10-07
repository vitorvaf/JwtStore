using System.Reflection.Metadata;
using JwtStore.Core;
using JwtStore.Core.Context.AccountContext.Entites;
using JwtStore.Core.Context.AccountContext.UseCases.Create.Contracts;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JwtStore.Infra.Context.AccountContext.UserCases.Create;

public class Service : IService
{
    public async Task SendConfirmationEmailAsync(User user, CancellationToken cancellationToken)
    {
        var client = new SendGridClient(Configuration.SendGrid.ApiKey);
        var from = new EmailAddress(Configuration.Email.DefaultFromEmail, Configuration.Email.DefaultFromName);
        var subject = "Confirm your email";
        var content = $" Código { user.Email.Verification.Code } ";
        var msg = MailHelper.CreateSingleEmail(from, new EmailAddress(user.Email.Address, user.Name), subject, content, content);
        await client.SendEmailAsync(msg, cancellationToken);
    }
}