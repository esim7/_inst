using System;
using Domain.Model;

namespace _inst.Models.Post
{
    public class PostCreateViewModel
    {
        public string PhotoPath { get; set; }
        public string Data { get; set; }

        public User User { get; set; }
    }
}