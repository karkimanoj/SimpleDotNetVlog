using System;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Data.Repositories;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepo;
        private readonly ApplicationDbContext _db;
        
        public TagController(ITagRepository tagRepo, ApplicationDbContext context)
        {
            _tagRepo = tagRepo;
            _db = context;
        }
        
        // GET
        public async Task<IActionResult> Index()
        {
            TagsViewModel tagsViewModel = new TagsViewModel()
            {
                Tags = await _tagRepo.All()
            };
            // tagsViewModel.Tags = await _tagRepo.All();
            return View(tagsViewModel);
        }
        
        // [HttpPost][AutoValidateAntiforgeryToken]
        // public async Task<IActionResult> Create(TagsViewModel tagsViewModel)
        // {
        //     
        //     // if (!ModelState.IsValid)
        //     // {
        //     //     TempData["failMessage"] = $"failed to create tag";
        //     //     return View("Index", tagsViewModel);
        //     // }
        //     if (true)
        //     {
        //         TempData["failMessage"] = $"failed to create tag";
        //         return View("Index", tagsViewModel);
        //     }
        //     
        //
        //     Tag newTag = tagsViewModel.Tag;
        //     _db.Add(newTag);
        //
        //     try
        //     {
        //         await _db.SaveChangesAsync();
        //         TempData["successMessage"] = $"successfully created new tag `{newTag.Name}`";
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch (Exception e)
        //     {
        //         TempData["failMessage"] = $"failed to create tag.";
        //         return View("Index", tagsViewModel);
        //     }
        //
        //
        // }
        //
        
        [HttpPost][AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("Name")]Tag tag)
        {
            if (!ModelState.IsValid)
            {
                TempData["failMessage"] = $"failed to create tag";
                TagsViewModel tagsViewModel = new TagsViewModel()
                {
                    Tag = tag,
                    Tags = await _tagRepo.All()
                };
                return View("Index", tagsViewModel);
            }
            
            Tag newTag = tag;
            _db.Add(newTag);

            try
            {
                await _db.SaveChangesAsync();
                TempData["successMessage"] = $"successfully created new tag `{newTag.Name}`";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["failMessage"] = $"failed to create tag due to internal server error";
                TagsViewModel tagsViewModel = new TagsViewModel()
                {
                    Tag = tag,
                    Tags = await _tagRepo.All()
                };
                return View("Index", tagsViewModel);
            }


        }
        
    }
}