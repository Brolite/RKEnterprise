using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RKEnterprise
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class EmailValidationAttribute : ValidationAttribute
    {
        private static readonly Regex _emailRegex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.Compiled);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Email address is required.");
            }

            string email = value.ToString();
            if (!_emailRegex.IsMatch(email))
            {
                return new ValidationResult("Please enter a valid email address.");
            }

            // Additional checks can be added here, such as domain-specific rules
            // Example: Only allow emails from a specific domain
            // if (!email.EndsWith("@example.com"))
            // {
            //     return new ValidationResult("Only example.com emails are allowed.");
            // }

            return ValidationResult.Success;
        }
    }

}