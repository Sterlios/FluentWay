namespace Telegram.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Nickname { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
