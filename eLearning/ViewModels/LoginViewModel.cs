using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public static implicit operator AreaAttribute(LoginViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}