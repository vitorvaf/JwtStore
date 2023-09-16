using JwtStore.Core.Context.AccountContext;
using JwtStore.Infra.AccountContext.Mapping;
using Microsoft.EntityFrameworkCore;

public class AppDbCotext : DbContext
{
    public AppDbCotext(DbContextOptions<AppDbCotext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}