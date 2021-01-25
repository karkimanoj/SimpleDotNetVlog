using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Post
    {
        public long PostId { get; set; }
        
        [Required][StringLength(450)]
        public string Title { get; set; }
        
        [Required][StringLength(450)][RegularExpression(@"([a-zA-Z0-9_]+)")]
        public string Slug { get; set; }
        [Required][StringLength(10000)]
        public string Body { get; set; }
        
        [Required][StringLength(450)]
        public string Image { get; set; }
        
        public long CategoryId { get; set; }
        
        public string AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        //relations
        public Category Category { get; set; }
        public ApplicationUser Author { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}