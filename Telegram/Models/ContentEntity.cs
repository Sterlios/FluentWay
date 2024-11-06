namespace Telegram.Models
{
    public class ContentEntity
    {
        public int Id { get; set; }
        public required string Message { get; set; } = string.Empty;
        public int PostId { get; set; }
        public PostEntity? Post { get; set; }
    }
}

