using Telegram.Models;
using Telegram.Repositories;

namespace Telegram.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Activate(
            int id,
            string nickname = "",
            string name = "",
            string surname = "",
            string email = "")
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            if (_userRepository.Add(id, nickname, name, surname, email))
                return;

            _userRepository.Update(id: id,
                                   nickname: nickname,
                                   name: name,
                                   surname: surname,
                                   email: email,
                                   isActive: true);
        }

        public void Deactivate(int id)
        {
            _userRepository.Update(id: id,
                                   isActive: false);
        }

        public void ChangeRole(int id, RoleEnum role)
        {
            _userRepository.Update(id: id,
                                   role: role);
        }
    }
}
