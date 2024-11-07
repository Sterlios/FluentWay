using System.ComponentModel.DataAnnotations.Schema;

namespace Telegram.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string? Nickname { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public required RoleEnum RoleId { get; set; }
        public bool IsActive { get; set; }
        public List<PostHistory> Histories { get; set; } = new List<PostHistory>();
        public Role? Role { get; set; }
    }
}
