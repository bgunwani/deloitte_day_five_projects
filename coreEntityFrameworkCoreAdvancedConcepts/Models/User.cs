using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace coreEntityFrameworkCoreAdvancedConcepts.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Range(18, 55, ErrorMessage = "Age must be between 18 and 55")]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = string.Empty;
        [Url(ErrorMessage = "Invalid Website Url")]
        public string Website { get; set; } = string.Empty;

        [RegularExpression("^[0-9]{10}", ErrorMessage = "Phone Number must be 10 digits.")]
        public string PhoneNuber { get; set; } = string.Empty;

        [MaxLength(50)]
        public string UserBio { get; set; } = string.Empty;

        [MinLength(6, ErrorMessage = "Password Must be at least 6 character long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [MinLength(6, ErrorMessage = "Password Must be at least 6 character long.")]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
