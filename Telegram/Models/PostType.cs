﻿namespace Telegram.Models
{
    public class PostType
    {
        public PostTypeEnum Id { get; set; }

        public string? Name { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
    }

    public enum PostTypeEnum
    {
        None = 0,
        Greeting = 1,
        Returned,
        OneTime,
    }
}

