using Telegram.Models;

namespace Telegram.Contracts
{
    public interface IUserRepository
    {
        void Add(UserEntity user);
        UserEntity? GetById(int id);
        void Update(UserEntity user);
    }
}