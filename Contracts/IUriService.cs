using System;

namespace Blog.Contracts
{
    public interface IUriService
    {
        public Uri GetPageUri(int? pageNo);
    }
}