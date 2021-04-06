using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Contracts
{
    public interface IPostService
    {
        public  Task<ShowBlogViewModel> GetShowBlogViewModel( AddCommentInputModel addCommentInputModel, int postId);
    }
}