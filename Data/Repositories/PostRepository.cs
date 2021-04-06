using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Contracts;
using Blog.Models;
using Blog.Services;
using Blog.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Blog.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IUriService _uriService;
        
        public PostRepository(ApplicationDbContext context, IUriService uriService)
        {
            _db = context;
            _uriService = uriService;
        } 
        
        public async Task<List<Post>> All()
        {
            return await _db.Post
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Include(p => p.PostTags)
                .ToListAsync();
        }

        public async  Task<bool> AnyForSlug(string slug)
        {
            return await _db.Post.AnyAsync(p => p.Slug == slug);
        }
        
        public async  Task<Post> FindWithCategoryAuthorAndCommentsForSlug(string slug)
        {
            return await _db.Post.Include(p => p.Author)
                .Include(p=> p.Category)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Slug == slug);
            
            // return await _db.Post.FirstOrDefaultAsyn(p => p.Slug == slug);
        }
        
        public async  Task<Post> FindWithCategoryAuthorAndCommentsForPostId(int postId)
        {
            return await _db.Post.Include(p => p.Author)
                .Include(p=> p.Category)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.PostId == postId);
     
        }

        public async  Task<bool> AnyForId(int postId)
        {
            return await _db.Post.AnyAsync(p => p.PostId == postId);
        }
        
        public async Task Load(Post post, string propertyName)
        {
            await _db.Entry(post).Navigation(propertyName).LoadAsync();
        }
        
        // public async  Task<Post> LoadCategoryAuthorAndComments(Post Post)
        // {
        //     return await _db.Post.Include(p => p.Author)
        //         .Include(p=> p.Category)
        //         .Include(p => p.Comments)
        //         .FirstOrDefaultAsync(p => p.Slug == slug);
        //     
        // }

        public async Task<Pagination<Post>> Paginate(int pageNo, int perPage = 10)
        {
            IQueryable<Post> postQuery = _db.Post;
            return await PaginationHelper<Post>.CreatePagedResponse(_uriService, postQuery, pageNo, perPage);
        }
    }
}