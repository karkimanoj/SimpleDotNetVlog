using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore; 

namespace Blog.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository 
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<List<Category>> All()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<bool> Exists(long id)
        {
            return await _db.Category.AnyAsync(c => c.CategoryId == id);
        }
    }
}