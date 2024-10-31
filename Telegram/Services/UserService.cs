using Telegram.Contracts;
using Telegram.Models;

namespace Telegram.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) =>
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        public bool AddUser(
            int id,
            string? nickname,
            string? name,
            string? surname)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            User? user = _userRepository.GetById(id);

            if (user is not null)
                return false;

            user = new User()
            {
                Id = id,
                Nickname = nickname,
                Name = name,
                LastName = surname,
            };

            _userRepository.Add(user);

            return true;
        }
    }
}
