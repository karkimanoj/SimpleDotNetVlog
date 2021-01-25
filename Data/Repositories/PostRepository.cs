using System;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
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
    }
}