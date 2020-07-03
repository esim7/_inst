using System.Collections.Generic;

namespace Domain.Model
{
    public class Post : BaseEntity
    {
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public string PhotoPath { get; set; }
        private ICollection<Comment> Comments { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}