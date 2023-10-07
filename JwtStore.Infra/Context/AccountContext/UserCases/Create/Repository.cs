using JwtStore.Core.Context.AccountContext.Entites;
using JwtStore.Core.Context.AccountContext.UseCases.Create.Contracts;
using JwtStore.Core.Context.AccountContext.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Context.AccountContext.UserCases.Create
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
            => _context = context;
            
        public async Task<bool> AnyAsync(Email email, CancellationToken cancellationToken)
         => await _context.Users.AsNoTracking().AnyAsync(x => x.Email == email, cancellationToken);       

        public async Task CreateAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}