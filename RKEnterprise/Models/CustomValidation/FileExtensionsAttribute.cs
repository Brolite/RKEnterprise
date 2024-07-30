using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace RKEnterprise.Models.CustomValidation
{
    public class FileExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public FileExtensionsAttribute(string extensions)
        {
            _extensions = extensions.Split(',');
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as HttpPostedFileBase;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).TrimStart('.').ToLowerInvariant();
                if (Array.Exists(_extensions, ext => ext.Equals(extension, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Invalid file type.");
        }
    }
}
