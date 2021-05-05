using System.Threading.Tasks;
using Blog.Data.Repositories;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostRepository _postRepository;

        public BlogController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        // GET
        
        public async Task<IActionResult> Index(int pageNo = 1)
        {
            Pagination<Post> allPosts = await _postRepository.Paginate(pageNo, 1);
            return View(allPosts);
        }

        //
        // public async Task<IActionResult> Show(string slug)
        // {
        //     Post post = await _postRepository.FindWithCategoryAuthorAndCommentsForSlug(slug);
        //     ShowBlogViewModel viewModel = new ShowBlogViewModel()
        //     {
        //         Post = post
        //     };
        //
        //     return View(viewModel);
        // }
    }
}