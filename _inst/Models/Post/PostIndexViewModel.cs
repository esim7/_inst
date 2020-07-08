using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Model;

namespace _inst.Models.Post
{
    public class PostIndexViewModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int LikeCount { get; set; }
        public ICollection<Domain.Model.Comment> Comments { get; set; }
        public string PhotoPath { get; set; }
        public string Data { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}