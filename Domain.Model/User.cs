using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Model
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}