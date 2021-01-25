using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> All();
    }
}