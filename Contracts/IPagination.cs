using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Services;

namespace Blog.Contracts
{
    public interface IPagination<T> where T : class
    {
        public List<T> Items { get;}
        public int PerPage { get; }
        public int Current { get; } 
        public int Last { get; }
        public Uri FirstPageUri { get; }
        public Uri LastPageUri { get; }
        public Uri NextPageUri { get; }
        public Uri PreviousPageUri { get; }
        public T this[int key] { get; set; }
        public  Task Paginate(IQueryable<T> dbQuery, int pageNo, int perPage = 10);

    }
}