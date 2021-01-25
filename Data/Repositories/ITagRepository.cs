using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Data.Repositories
{
    public interface ITagRepository
    {
        Task<List<Tag>> All();
    }
}