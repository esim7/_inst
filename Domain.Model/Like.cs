using System.Collections;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Like : BaseEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public string UserId { get; set; }
    }
}