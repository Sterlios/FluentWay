using Telegram.Contracts;
using Telegram.Models;

namespace Telegram.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) =>
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        public bool RegisterUser(
            int id,
            string? nickname,
            string? name,
            string? surname)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            UserEntity? user = _userRepository.GetById(id);

            if (user is not null)
            {
                Activate(user);
                return false;
            }

            user = new UserEntity()
            {
                Id = id,
                Nickname = nickname,
                Name = name,
                LastName = surname,
                IsActive = true
            };

            _userRepository.Add(user);

            return true;
        }

        public void DeactivateUser(int id)
        {
            UserEntity? user = _userRepository.GetById(id)
                ?? throw new ArgumentOutOfRangeException(nameof(id));

            user.IsActive = false;

            _userRepository.Update(user);
        }

        private void Activate(UserEntity user)
        {
            user.IsActive = true;
            _userRepository.Update(user);
        }
    }
}
