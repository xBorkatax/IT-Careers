using System.ComponentModel.DataAnnotations;

namespace Exam.Web.Models
{
    public class RegisterViewModel 
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        //[Required]
        //[EmailAddress]
        //public string Email { get; set; } = null!;
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string UserName { get; set; }

        [Required]
        //[Compare(nameof(PasswordRepeat))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        //[Required]
        //[DataType(DataType.Password)]
        //public string PasswordRepeat { get; set; } = null!;
    }
}
