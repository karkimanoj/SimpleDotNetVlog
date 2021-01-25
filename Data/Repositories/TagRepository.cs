using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore; 

namespace Blog.Data.Repositories
{
    public class TagRepository : ITagRepository 
    {
        private readonly ApplicationDbContext _db;

        public TagRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<List<Tag>> All()
        {
            return await _db.Tag.ToListAsync();
        }
    }
}