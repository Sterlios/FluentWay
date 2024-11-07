namespace Telegram.Models
{
    public class PostTypeEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<PostEntity> Posts { get; set; } = new List<PostEntity>();
    }
}

