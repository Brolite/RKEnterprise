using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RKEnterprise.Models.CustomValidation
{
    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;

        public MaxWordsAttribute(int maxWords)
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var message = value as string;
            if (message != null)
            {
                var wordCount = message.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                if (wordCount > _maxWords)
                {
                    return new ValidationResult($"The message should not exceed {_maxWords} words.");
                }
            }
            return ValidationResult.Success;
        }
    }

}