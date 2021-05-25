using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marvin.IDP.Quickstart.PasswordReset
{
    public class RequestPasswordViewModel
    {
        [Required]
        [MaxLength(200)]
        [Display(Name ="Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
