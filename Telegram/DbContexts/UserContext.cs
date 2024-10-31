using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Telegram.Models;

namespace Telegram.DbContexts
{
    public class UserContext : DbContext
    {
        //private readonly DbNameConvention _userConvention;

        public UserContext(IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(configuration));

            IConfigurationSection section = configuration.GetSection("DbNameConventions:Actual");

            //if (section is null)
            //    _userConvention = new DbNameConvention();
            //else
            //    _userConvention = section.Get<DbNameConvention>()
            //        ?? throw new ArgumentNullException(nameof(_userConvention));
        }

        //public UserContext() =>_userConvention = new DbNameConvention();

        public UserContext()
        {
            Users = new List<User>();
        }

        public List<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<User>().ToTable(name: $"Users", schema: "Actual");
    }
}
