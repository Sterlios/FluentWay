﻿namespace Telegram.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime? RepetitionStep { get; set; }
        public int TypeOfTimeId { get; set; }
        public int ContentId { get; set; }
        public TypeOfTime? TypeOfTime { get; set; }
        public Content? Content { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<PostHistory> Histories { get; set; } = new List<PostHistory>();
    }
}
