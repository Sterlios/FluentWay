namespace Telegram.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime? RepetitionStep { get; set; }
        public PostTypeEnum PostTypeId { get; set; }
        public int ContentId { get; set; }
        public PostType? PostType { get; set; }
        public Content? Content { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<PostHistory> Histories { get; set; } = new List<PostHistory>();
    }
}

