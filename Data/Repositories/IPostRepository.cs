using System.Threading.Tasks;

namespace Blog.Data.Repositories
{
    public interface IPostRepository
    {
        public  Task<bool> AnyForSlug(string slug);
    }
}