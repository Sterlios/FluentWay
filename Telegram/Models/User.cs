namespace Telegram.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Nickname { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public required int RoleId { get; set; }
        public bool IsActive { get; set; }
        public List<PostHistory> Histories { get; set; } = new List<PostHistory>();
        public Role? Role { get; set; }
    }
}
