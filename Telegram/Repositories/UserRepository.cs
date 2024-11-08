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

        public bool Add(
            int id,
            string nickname = "",
            string name = "",
            string surname = "",
            string email = "")
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            if (_context.Users.FirstOrDefault(user => user.Id == id) != null)
                return false;

            User user = new User()
            {
                Id = id,
                Nickname = nickname,
                Name = name,
                Surname = surname,
                Email = email
            };

            _context.Users.Add(user);
            _context.SaveChangesAsync();

            return true;
        }

        public void Update(
            int id,
            bool? isActive = null,
            string nickname = "",
            string name = "",
            string surname = "",
            string email = "",
            RoleEnum role = RoleEnum.None)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            User user = _context.Users.FirstOrDefault(user => user.Id == id)
                ?? throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(nickname) == false)
                user.Nickname = nickname;

            if (string.IsNullOrWhiteSpace(name) == false)
                user.Name = name;

            if (string.IsNullOrWhiteSpace(surname) == false)
                user.Surname = surname;

            if (string.IsNullOrWhiteSpace(email) == false)
                user.Email = email;

            if (role != RoleEnum.None)
                user.RoleId = role;

            if (isActive is not null)
                user.IsActive = (bool)isActive;

            _context.Users.Update(user);
            _context.SaveChangesAsync();
        }
    }
}
