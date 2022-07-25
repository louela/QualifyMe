using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QualifyMe.ViewModels
{
    public class StudentRegister
    {
        [Required]
        public string StudentID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string StudentName { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }
       

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string StudentMobile { get; set; }

    }
}
