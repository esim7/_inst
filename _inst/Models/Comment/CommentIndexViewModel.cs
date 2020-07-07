using System;

namespace _inst.Models.Comment
{
    public class CommentIndexViewModel
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Text { get; set; }
        public string CommentAuthor { get; set; }
    }
}