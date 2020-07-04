using System;
using Domain.Model;

namespace _inst.Models.Post
{
    public class PostDetailViewModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public string PhotoPath { get; set; }

        public User User { get; set; }
    }
}