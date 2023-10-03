using JwtStore.Core.Context.AccountContext.Entites;

namespace JwtStore.Core.Context.AccountContext.UseCases.Create.Contracts
{
    public interface IService
    {
        Task SendConfirmationEmailAsync(User user, CancellationToken cancellationToken);
    }
}