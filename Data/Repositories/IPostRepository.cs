using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Http;

namespace Blog.Data.Repositories
{
    public interface IPostRepository
    {
        public  Task<bool> AnyForSlug(string slug);
        public  Task<List<Post>> All();

        public  Task Load(Post post, string propertyName);

        public  Task<Pagination<Post>> Paginate(int pageNo, int perPage);
        
    }
}