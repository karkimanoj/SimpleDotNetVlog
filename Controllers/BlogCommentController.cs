using System;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Contracts;
using Blog.Data.Repositories;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogCommentController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ApplicationDbContext _db;
        private readonly IPostService _postService;
        public BlogCommentController(ApplicationDbContext dbContext ,IPostRepository postRepository, IPostService postService)
        {
            _db = dbContext;
            _postRepository = postRepository;
            _postService = postService;
        }
        
        // GET
        public async Task<IActionResult> Show(string slug)
        {
            Post post = await _postRepository.FindWithCategoryAuthorAndCommentsForSlug(slug);
            ShowBlogViewModel viewModel = new ShowBlogViewModel()
            {
                Post = post
            };

            return View(viewModel);
        }
      
        [HttpPost][ValidateAntiForgeryToken][ActionName("Show")]
        public async Task<IActionResult> CreateComment(AddCommentInputModel model)
        {
            long postId = model.PostId;
            if (!await _postRepository.AnyForId(postId))
                return NotFound();

            if (!ModelState.IsValid)
            {
                // var test = await _postService.GetShowBlogViewModel(model, postId);
                
                return View( await _postService.GetShowBlogViewModel(model, postId));
            }

            Comment comment = new Comment()
            {
                Name = model.Name,
                Email = model.Email,
                Description = model.Description,
                PostId = postId
            };

            try
            {
                _db.Add(comment);
                await _db.SaveChangesAsync();
                TempData["successMessage"] = "successfully  added new comment";
                
                return RedirectToAction("show", "Post");
            }
            catch (Exception e)
            {
                TempData["failMessage"] = "failed to add new comment";
                return View( await _postService.GetShowBlogViewModel(model, postId));
                //"/Views/BlogComment/show.cshtml",
            }
        }
    }
}