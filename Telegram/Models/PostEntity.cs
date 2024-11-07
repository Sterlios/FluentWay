namespace Telegram.Models
{
    public class PostEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime? RepetitionStep { get; set; }
        public int TypeId { get; set; }
        public PostTypeEntity? Type { get; set; }
        public List<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
        public int ContentId { get; set; }
        public ContentEntity? Content { get; set; }
        public List<PostHistoryEntity> Histories { get; set; }
    }
}

