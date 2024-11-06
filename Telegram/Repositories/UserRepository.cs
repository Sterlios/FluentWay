
using Telegram.Contracts;
using Telegram.DbContexts;
using Telegram.Models;

namespace Telegram.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext) =>
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));

        public void Add(UserEntity user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (_userContext.Users.FirstOrDefault(innerUser => innerUser.Id == user.Id) is null)
                _userContext.Users.Add(user);
        }

        public UserEntity? GetById(int id) =>
            _userContext.Users.Find(id);

        public void Update(UserEntity user) =>
            _userContext.Users.Update(user);
    }
}
