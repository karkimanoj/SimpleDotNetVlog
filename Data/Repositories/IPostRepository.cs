using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Data.Repositories
{
    public interface IPostRepository
    {
        public  Task<bool> AnyForSlug(string slug);
        public  Task<List<Post>> All();

        public  Task Load(Post post, string propertyName);
    }
}