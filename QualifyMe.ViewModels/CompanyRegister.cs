using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class CompanyRegister
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string CompanyName { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string CompanyConfirmPassword { get; set; }


        [Required]
        public string CompanyMobile { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
        [Required]
        public string CompanyDescription { get; set; }
    }
}
