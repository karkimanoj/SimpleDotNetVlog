using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Contracts;
using Blog.Services;

namespace Blog.Utils
{
    public static class PaginationHelper<T> where T : class
    {
        public static async Task<Pagination<T>> CreatePagedResponse(IUriService uriService, IQueryable<T> query, int pageNo, int perPage)
        {
            var newPagination =  new Pagination<T>(uriService);
            await newPagination.Paginate(query, pageNo, perPage);
            return newPagination;
        }
    }
}


