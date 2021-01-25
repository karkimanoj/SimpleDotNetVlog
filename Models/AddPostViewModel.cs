using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Models
{
    public class AddPostViewModel
    {
        [Required][StringLength(256)]
        public string Title { get; set; }
        
        [Required][StringLength(256)][RegularExpression(@"([a-zA-Z0-9_]+)")]
        public string Slug { get; set; }
        [Required][StringLength(10000)]
        public string Body { get; set; }
        
        // [Required][StringLength(256)]
        [Required][DataType(DataType.Upload)][MaxFileSize(10 * 1024 * 1024)][AllowedFileExtension(".jpg", ".png", ".jpeg")]
        public IFormFile Image { get; set; }
        
        [Required]
        public long CategoryId { get; set; }
      
        public List<long> TagIds { get; set; } //not required
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Tags { get; set; }
        
        
       
    }
}