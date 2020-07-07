using System;
using Domain.Model;

namespace _inst.Models.Post
{
    public class PostIndexViewModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public string PhotoPath { get; set; }
        public string Data { get; set; }

        public string UserId { get; set; }
    }
}