using JwtStore.Core.Context.AccountContext.Entites;
using JwtStore.Core.Context.AccountContext.ValueObjects;

namespace JwtStore.Core.Context.AccountContext.UseCases.Create.Contracts
{
    public interface IRepository
    {
        Task<bool> AnyAsync(Email email, CancellationToken cancellationToken);
        Task CreateAsync(User user, CancellationToken cancellationToken);
    }
}