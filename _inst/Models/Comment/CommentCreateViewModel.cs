﻿using System;

namespace _inst.Models.Comment
{
    public class CommentCreateViewModel
    {
        public string Text { get; set; }
        public int PostId { get; set; }
        public string CommentAuthor { get; set; }
    }
}