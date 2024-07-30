using RKEnterprise.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RKEnterprise.Models
{
    public class CareerModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        //[EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        //[RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [MaxLength(100, ErrorMessage = "The message should not exceed 100 words.")]
        //[MaxWords(1, ErrorMessage = "The message should not exceed 100 words.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Please upload your CV.")]
        [DataType(DataType.Upload)]
        //[FileExtensions(ErrorMessage = "Only PDF, DOC, and DOCX files are allowed.")] //Not woking in validation.js, making work in HomeController
        public HttpPostedFileBase CV { get; set; }
    }
}
