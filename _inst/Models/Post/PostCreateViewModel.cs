using System;
using Domain.Model;
using Microsoft.AspNetCore.Http;

namespace _inst.Models.Post
{
    public class PostCreateViewModel
    {
        public string PhotoPath { get; set; }
        public string Data { get; set; }
        public IFormFile Photo { get; set; }
        public User User { get; set; }
    }
}