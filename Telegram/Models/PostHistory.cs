namespace Telegram.Models
{
    public class PostHistory
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime SentDate { get; set; }
        public required Post Post { get; set; }
        public required User User { get; set; }
    }
}

