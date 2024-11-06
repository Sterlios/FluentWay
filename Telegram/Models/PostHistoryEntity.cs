namespace Telegram.Models
{
    public class PostHistoryEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public PostEntity Post { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTime SentDate { get; set; }
    }
}

