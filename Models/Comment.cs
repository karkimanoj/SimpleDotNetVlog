using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        public long CommentId { get; set; }

        public long PostId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        [Required][StringLength(255)][EmailAddress][DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required][StringLength(2000)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        
        //relations
        public Post Post { get; set; }
    }
}