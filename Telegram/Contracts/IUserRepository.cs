using Telegram.Models;

namespace Telegram.Contracts
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetById(int id);
    }
}