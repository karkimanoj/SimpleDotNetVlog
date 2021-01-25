using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Tag 
    {
        public long TagId { get; set; }
        
        [Required][StringLength(256)]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        //relations
        public List<PostTag> PostTags { get; set; }
        
    }
}