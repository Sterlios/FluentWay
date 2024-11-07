namespace Telegram.Models
{
    public class TypeOfTime
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}

