using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class AddCommentInputModel
    {
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }
        [Required][StringLength(255)][EmailAddress][DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required][StringLength(2000)]
        public string Description { get; set; }
        
        public long PostId { get; set; }
    }
}