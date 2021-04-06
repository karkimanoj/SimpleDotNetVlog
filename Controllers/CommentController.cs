using System;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Contracts;
using Blog.Data.Repositories;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
 
    public class CommentController : Controller
    {

        private readonly IPostRepository _postRepository;
        private readonly ApplicationDbContext _db;
        private readonly IPostService _postService;
        public CommentController(ApplicationDbContext dbContext ,IPostRepository postRepository, IPostService postService)
        {
            _db = dbContext;
            _postRepository = postRepository;
            _postService = postService;
        }
        
 
         [HttpPost][ValidateAntiForgeryToken]
         public async Task<IActionResult> Create(AddCommentInputModel model, int postId)
         {
             if (await _postRepository.AnyForId(postId))
                 return NotFound();

             if (!ModelState.IsValid)
             {
                 return View("/Views/Blog/show.cshtml", await _postService.GetShowBlogViewModel(model, postId));
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
                 return View("/Views/Blog/show.cshtml", await _postService.GetShowBlogViewModel(model, postId));
             }
             
             
         }
         
    }
}