using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Data.Repositories;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IPostRepository _postRepository;
      
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public PostController(ApplicationDbContext context, ICategoryRepository categoryRepository, ITagRepository tagRepository, IPostRepository postRepository,IConfiguration config, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _postRepository = postRepository;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index(int pageNo)
        {
            //List<Post> allPosts = await _postRepository.All();
            Pagination<Post> allPosts = await _postRepository.Paginate(pageNo, 1);
            
            
            //return Ok(await _postRepository.Paginate(HttpContext.Request));
            
            return View(allPosts);
        }

        public async Task<IActionResult> Create()
        {
            List<SelectListItem> categories = (await _categoryRepository.All())
                .ConvertAll(category => new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.Name
                });

            List<SelectListItem> tags = (await _tagRepository.All())
                .ConvertAll(tag => new SelectListItem()
                {
                    Value = tag.TagId.ToString(),
                    Text = tag.Name
                });
            
            AddPostViewModel addPostViewModel = new AddPostViewModel()
            {
                Categories = categories,
                Tags = tags
            };
            
            return View(addPostViewModel);
        }
        
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await AddViewDataForPost(model);
                return View(model);
            }
            
            
            //start: upload image
            string uuid = Guid.NewGuid().ToString();
            string originalExt = Path.GetExtension(model.Image.FileName);
            string fileName = $"{uuid}.{originalExt}";
            
            string imageDirectoryName = "images";
            string imageDirectoryPath = Path.Combine(_hostEnvironment.WebRootPath, imageDirectoryName);
            string imagePath = Path.Combine(imageDirectoryPath, fileName);

            if (!Directory.Exists(imageDirectoryPath))
            {
                try
                {
                    Directory.CreateDirectory(imageDirectoryPath);
                }
                catch (Exception e)
                {
                    TempData["failMessage"] = $"failed to create new post {model.Title}";
                    await AddViewDataForPost(model);
                    return View(model);
                }
            }
            
            using (FileStream fileStream = new FileStream(imagePath, FileMode.Create))
            { 
                await model.Image.CopyToAsync(fileStream);
            }
            //end: upload image

            Post post = new Post()
            {
                Title = model.Title,
                Slug = model.Slug,
                Image = Path.Combine(imageDirectoryName, fileName),
                Body = model.Body,
                CategoryId = model.CategoryId,
                AuthorId = _userManager.GetUserId(HttpContext.User)
            };

            if (model.TagIds != null && model.TagIds.Any())
            {
                post.PostTags = new List<PostTag>();
                foreach (long tagId in model.TagIds)
                {
                    post.PostTags.Add(new PostTag()
                    {
                        TagId = tagId
                    });
                }
            }
            
            _db.Add(post);
            
            /*
             * todo : db transaction is automatically used for SaveChanges. so no need. only if  _db.SaveChangesAsync is called more than once, manually call _db.Database.BeginTransaction()
             */
            
            try
            {
                await _db.SaveChangesAsync();
                TempData["successMessage"] = $"successfully created new post `{post.Title}`";
                return RedirectToAction(nameof(Index));
              
            }
            catch (Exception)
            {
                TempData["failMessage"] = $"failed to create new post {model.Title}";
                if (await _postRepository.AnyForSlug(model.Slug))
                    TempData["failMessage"] = "slug already used";
                
                await AddViewDataForPost(model);
                return View(model);
            }
          
        }
        
        
        
        private async Task AddViewDataForPost(AddPostViewModel model)
        {
            model.Categories = (await _categoryRepository.All())
                .ConvertAll(category => new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.Name
                });

            model.Tags = (await _tagRepository.All())
                .ConvertAll(tag => new SelectListItem()
                {
                    Value = tag.TagId.ToString(),
                    Text = tag.Name
                });
        }
    }
        
    //     [HttpPost][ValidateAntiForgeryToken]
    //     public async Task<IActionResult> Create(AddPostViewModel addPostViewModel)
    //     {
    //         
    //     }
    // }
}