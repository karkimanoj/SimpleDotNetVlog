using System.Collections.Generic;

namespace Blog.Contracts
{
    public interface IPagination<T> where T : class
    {
        public List<T> Items { get;}
        public int PerPage { get; }
        public int Current { get; } 
        public int Last { get; }
    }
}