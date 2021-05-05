using System.Threading.Tasks;
using Blog.Contracts;
using Blog.Data.Repositories;
using Blog.Models;

namespace Blog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ShowBlogViewModel> GetShowBlogViewModel( AddCommentInputModel addCommentInputModel, long postId)
        {
            return new ShowBlogViewModel()
            {
                Post = await _postRepository.FindWithCategoryAuthorAndCommentsForPostId(postId),
                AddCommentInputModel = addCommentInputModel
            };
        }
    }
}