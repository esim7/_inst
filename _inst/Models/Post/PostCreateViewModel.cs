using System;
using Domain.Model;

namespace _inst.Models.Post
{
    public class PostCreateViewModel
    {
        public string PhotoPath { get; set; }
        public string Data { get; set; }

        public User User { get; set; }

        public PostCreateViewModel()
        {
            Random random = new Random();
            PhotoPath = "https://image.freepik.com/free-photo/tropical-green-leaves-background_53876-88" + random.Next(90, 600) + ".jpg";
        }
    }
}