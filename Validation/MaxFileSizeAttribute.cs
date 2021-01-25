using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Blog.Validation
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        public int MaxSize { get; } //in bytes

        public MaxFileSizeAttribute(int maxSize)
        {
            MaxSize = maxSize;
        }

        public string GetErrorMessage() => $"File size must not exceed {MaxSize} bytes";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;

            if (file != null && file.Length > MaxSize)
                return new ValidationResult(GetErrorMessage());
            
            return ValidationResult.Success;
        }
    }
    
}