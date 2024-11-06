namespace Telegram.Models
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public List<UserEntity> Users { get; set; } = new List<UserEntity>();
        public List<PostEntity> Posts { get; set; } = new List<PostEntity>();
    }
}
