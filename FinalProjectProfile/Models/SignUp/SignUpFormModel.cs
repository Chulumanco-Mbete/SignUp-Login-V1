using Syncfusion.Maui.DataForm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectProfile.Models.SignUp
{
    public class SignUpFormModel : IDataErrorInfo
    {
        [Display(Prompt = "Enter your first name", Name = "First name")]
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50, ErrorMessage = "First name should not exceed 20 characters")]
        public string FirstName { get; set; }

        [Display(Prompt = "Enter your last name", Name = "Last name")]
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(50, ErrorMessage = "First name should not exceed 20 characters")]
        public string LastName { get; set; }

        [Display(Prompt = "Enter your email", Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Display(Prompt = "Enter your mobile number", Name = "Mobile number")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Please enter a valid number")]
        public string MobileNumber { get; set; }

        [Display(Prompt = "Enter your password", Name = "Password")]
        [DataType(DataType.Password)]
        [DataFormDisplayOptions(ColumnSpan = 2, ValidMessage = "Password strength is good")]
        [Required(ErrorMessage = "Please enter the password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{8,}$",
        ErrorMessage = "A minimum 8-character password should contain a combination of uppercase and lowercase letters.")]
        public string Password { get; set; }

        [Display(Prompt = "Confirm password", Name = "Re-enter Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter the password")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string RetypePassword { get; set; }

        [Display(AutoGenerateField = false)]
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        [Display(AutoGenerateField = false)]
        public string this[string name]
        {
            get
            {
                string result = string.Empty;
                if (name == nameof(RetypePassword) && Password != RetypePassword)
                {
                    result = string.IsNullOrEmpty(RetypePassword) ? string.Empty : "The passwords do not match";
                }

                return result;
            }
        }
    }
}

