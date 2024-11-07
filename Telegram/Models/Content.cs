namespace Telegram.Models
{
    public class Content
    {
        public int Id { get; set; }
        public required string Message { get; set; } = string.Empty;
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}

