using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Contracts;
using Microsoft.EntityFrameworkCore; 

namespace Blog.Services
{
    public class Pagination<T> : IPagination<T> where T : class
    {
        private IUriService _uriService;
        public List<T> Items { get; set; }
        public int PerPage { get; private set; }
        
        public int Current { get; private set; }
        public int Total { get; private set; }
        public int From => Skip + 1;
        public int To => Skip + CurrentTotal;
        
        private int Skip => (Current - 1) * PerPage;
        public int CurrentTotal => Total - Skip >= PerPage ? PerPage : Total - Skip;
        private int? Previous => Current > 1 ? Current - 1 : (int?) null;
        private int? Next => Last > Current ? Current + 1 : (int?) null;
        public int Last => (int) Math.Ceiling((decimal) Total/PerPage);
        //start uri
        public Uri FirstPageUri =>  _uriService.GetPageUri(1);
        public Uri LastPageUri =>  _uriService.GetPageUri(Last);
        public Uri NextPageUri =>  _uriService.GetPageUri(Next);
        
        public Uri PreviousPageUri =>  _uriService.GetPageUri(Previous);
        //end uri
        public Pagination(IUriService uriService)
        {
            _uriService = uriService;
            Items = new List<T>();
            Current = 1;
        }

        public T this[int key]
        {
            get => Items[key];
            set => Items.Add(value);
        }
        
        public async Task Paginate(IQueryable<T> dbQuery, int pageNo, int perPage = 10)
        {
            //_uriService = uriService;
            PerPage = perPage;
            Current = pageNo;
            Total = await dbQuery.CountAsync();
            Items = await dbQuery.Skip(Skip).Take(CurrentTotal).ToListAsync();
        }
    }
}