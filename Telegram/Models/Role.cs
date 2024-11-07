namespace Telegram.Models
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
