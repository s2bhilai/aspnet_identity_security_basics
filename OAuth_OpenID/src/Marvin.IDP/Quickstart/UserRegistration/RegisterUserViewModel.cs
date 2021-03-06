using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvin.IDP.Quickstart.UserRegistration
{
    public class RegisterUserViewModel
    {
        [MaxLength(200)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [MaxLength(200)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        //public SelectList CountryCodes { get; set; } =
        //    new SelectList(
        //        new[]
        //        {
        //            new { Id = "BE", Value="Belgium"},
        //            new { Id = "US", Value="United States"},
        //            new { Id = "IN", Value="INdia"}
        //        }, "Id", "Value");

        public List<SelectListItem> CountryCodes { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem {Text = "BE", Value = "Belgium"},
                new SelectListItem {Text = "US", Value = "United States"},
                new SelectListItem {Text = "IN", Value = "INdia"}
            };

        public string ReturnUrl { get; set; }
    }
}
