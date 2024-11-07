namespace Telegram.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string? Nickname { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public RoleEntity? Role { get; set; }
        public bool IsActive { get; set; }
        public List<PostHistoryEntity> Histories { get; set; } = new List<PostHistoryEntity>();
    }
}
