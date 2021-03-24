using System;
using Blog.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Blog.Services
{
    public class UriService : IUriService
    {
        //private readonly HttpContext _httpContext;
        private readonly string _baseUri;
        private readonly string route;
        
        // public UriService(HttpRequest request)
        // {
        //     // _httpContext = httpContextAccessor.HttpContext;
        //     // var request = _httpContext.Request;
        //     _baseUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
        //     route = request.Path.Value;
        // }
        
        public UriService(IHttpContextAccessor httpContextAccessor)
        {
            var request = httpContextAccessor.HttpContext.Request;
            _baseUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
            route = request.Path.Value;
        }
        
        public Uri GetPageUri(int? pageNo)
        {
            if (pageNo == null)
                return null;
            
            var enpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(enpointUri.ToString(), "pageNo", pageNo.ToString());
            // modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}