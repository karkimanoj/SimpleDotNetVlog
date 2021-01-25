using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Blog.Validation
{
    public class AllowedFileExtensionAttribute : ValidationAttribute
    {
        public string[] ValidExtensions { get; }
        public AllowedFileExtensionAttribute(params string[] extensions)
        {
            ValidExtensions = extensions;
        }

        public string GetFailMessage() => $"File type Not supported";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;
            
            //if file and file has valid extensions
            if (file != null && ValidExtensions.Contains(Path.GetExtension(file.FileName)))
                return new ValidationResult(GetFailMessage());

            return ValidationResult.Success;
        }
    }
}