using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _db;
        public PostRepository(ApplicationDbContext context) => _db = context;

        public async  Task<bool> AnyForSlug(string slug)
        {
            return await _db.Post.AnyAsync(p => p.Slug == slug);
        }

        public async Task<List<Post>> All()
        {
            return await _db.Post
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Include(p => p.PostTags)
                .ToListAsync();
        }

        public async Task Load(Post post, string propertyName)
        {
            await _db.Entry(post).Navigation(propertyName).LoadAsync();
        }
        
  
        
    }
}