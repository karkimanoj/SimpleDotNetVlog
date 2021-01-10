using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Identity.Authorization;
using Blog.Areas.Identity.Data;
using Blog.Areas.Identity.Data.Seeder;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; //always use Microsoft.EntityFrameworkCore in .net core instead of System.Data.Entity; 

namespace Blog.Controllers
{
     [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public CategoryController(ApplicationDbContext context)
        {
            _db = context;
        }
        // GET
        
        public async Task<IActionResult> Index()
        {
            //return Ok(user); return json . can be use d like dd() in php
        
            //return Ok(PermissionAndUserPermissionSeederData.Permissions);
            return View(await _db.Category.ToListAsync());
        }
        
        [PermissionAuthorize("add_category")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Category category)
        {
            if (!ModelState.IsValid)
            {
                TempData["failMessage"] = "failed to create new category ";
                return View(category);
            }
            //return View(category);
            //DateTime now = ;
            //category.CreatedAt = category.UpdatedAt = new DateTime();
            
            _db.Add(category);
            try
            {
                await _db.SaveChangesAsync();
                TempData["successMessage"] = $"successfully created new category `{category.Name}`";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["failMessage"] = "failed to create new category ";
                return View(category);
            }
        }
        
        
        public async Task<IActionResult> Edit(int id)
        {
            var category = await  _db.Category.FirstOrDefaultAsync(c => c.CategoryId == id);
            
            if (category == null)
                return NotFound();

            return View(category);
        }
        
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CategoryId", "Name")] Category category, int id)
        {
            if (category.CategoryId != id) return NotFound();

            if (!ModelState.IsValid)
            {
                TempData["failMessage"] = $"failed to update category `{category.Name}`";
                return View(category);
            }

            _db.Update(category);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await CategoryExists(id)))
                    return NotFound();
                else
                    throw;
            }
            catch (Exception)
            {
                TempData["failMessage"] = "failed! internal server error. could not update category";
                return View(category);
            }

            TempData["successMessage"] = $"successfully updated category `{category.Name}`";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CategoryExists(int id)
        {
            return await _db.Category.AnyAsync(c => c.CategoryId == id);
        }
        
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Category selectedCategory = await _db.Category.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (selectedCategory == null) return NotFound();
            
            _db.Remove(selectedCategory);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                TempData["failMessage"] = "failed! internal server error. cannot delete category.";
                return RedirectToAction(nameof(Index));
                //return Redirect(Request.Headers["Referer"].ToString()); redirects back
            }
            
            TempData["successMessage"] = $"successfully deleted category `{selectedCategory.Name}`";

            return RedirectToAction(nameof(Index));

        }
    }
}