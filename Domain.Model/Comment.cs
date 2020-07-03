namespace Domain.Model
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public string CommentAuthor { get; set; }

        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}