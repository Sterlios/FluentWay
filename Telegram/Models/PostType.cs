using System.ComponentModel.DataAnnotations.Schema;

namespace Telegram.Models
{
    public class PostType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public PostTypeEnum Id { get; set; }
        public string? Name { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }

    public enum PostTypeEnum
    {
        Greeting = 1,
        Returned,
        OneTime,
    }
}

