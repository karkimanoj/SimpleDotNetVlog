using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Blog.Contracts;

namespace Blog.Services
{
    public class Pagination<T> : IPagination<T> where T : class
    {
        public List<T> Items { get; set; }
        public int PerPage { get; private set; }
        
        public int Current { get; private set; }
        public int Total { get; private set; }
        public int From => Skip + 1;
        public int To => Skip + CurrentTotal;
        public int Last => (int) Math.Ceiling((decimal) Total/PerPage);se
        private int Skip => (Current - 1) * PerPage;
        public int CurrentTotal => Total - Skip >= PerPage ? PerPage : Total - Skip;
        private int? Next => Last > Current ? Current + 1 : (int?) null;
        private int? Previous => Current > 1 ? Current - 1 : (int?) null;
        
        public Pagination()
        {
            Items = new List<T>();
            PerPage = 10;
            Current = 1;
        }

        public T this[int key]
        {
            get => Items[key];
            set => Items.Add(value);
        }
        
        public async Task Paginate(IQueryable<T> dbQuery)
        {
            Total = await dbQuery.CountAsync();
            Items = await dbQuery.Skip(Skip).Take(CurrentTotal).ToListAsync();
        }
        
        public async Task Paginate(IQueryable<T> dbQuery, int pageNo, int perPage)
        {
            PerPage = perPage;
            Current = pageNo;
            await Paginate(dbQuery);
        }
    }
}