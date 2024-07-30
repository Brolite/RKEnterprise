using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RKEnterprise
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        private static readonly Regex _phoneNumberRegex = new Regex(@"^(?:\+91|91)?[789]\d{9}$", RegexOptions.Compiled);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !_phoneNumberRegex.IsMatch(value.ToString()))
            {
                return new ValidationResult("Please enter a valid Indian phone number.");
            }

            return ValidationResult.Success;
        }
    }
}