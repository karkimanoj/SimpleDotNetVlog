namespace Blog.Models
{
    public class PostTag
    {
        public long PostTagId { get; set; }
        
        public long PostId { get; set; }
        
        public long TagId { get; set; }
        
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}