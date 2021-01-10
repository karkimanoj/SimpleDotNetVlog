namespace Blog.Models
{
    public class PermissionUser
    {
        public long PermissionUserId { get; set; }
        
        public long PermissionId { get; set; }
        public Permission Permission { get; set;}
        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}