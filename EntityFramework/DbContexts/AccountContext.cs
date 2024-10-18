using FluentWay.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FluentWay.EntityFramework.DbContexts
{
    public class AccountContext : IdentityDbContext<User>
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
