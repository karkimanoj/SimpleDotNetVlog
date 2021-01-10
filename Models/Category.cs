using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        [Required, StringLength(256)]
        //, RegularExpression(@"\w")
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // public List<Post> Posts { get; set; }
        public List<Post> Posts { get; set;}
    }
}