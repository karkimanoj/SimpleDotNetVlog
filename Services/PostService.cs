using System.Threading.Tasks;
using Blog.Data.Repositories;
using Blog.Models;

namespace Blog.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ShowBlogViewModel> GetShowBlogViewModel( AddCommentInputModel addCommentInputModel, int postId)
        {
            return new ShowBlogViewModel()
            {
                Post = await _postRepository.FindWithCategoryAuthorAndCommentsForPostId(postId),
                AddCommentInputModel = addCommentInputModel
            };
        }
    }
}