using Microsoft.EntityFrameworkCore;
using Telegram.DbContexts;
using Telegram.Models;

namespace Telegram.Repositories
{
    public class UserRepository
    {
        private readonly TelegramDbContext _context;

        public UserRepository(TelegramDbContext context) =>
            _context = context;

        public User GetById(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            User user = _context.Users
                .FirstOrDefaultAsync(user => user.Id == id)
                .Result
                ?? throw new ArgumentNullException(nameof(user));

            return user;
        }

        public List<User> GetAllActive() =>
            _context.Users.Where(user => user.IsActive).ToList();

        public void Add(int id, string? nickname, string? name, string? surname, string? email)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        }
    }
}
