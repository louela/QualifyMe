using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace QualifyMe.ViewModels
{
    public class StudentRegister
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string Gender { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
     
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string StudentFirstName { get; set; }
    
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string StudentLastName { get; set; }
        public string ImagePath { get; set; }
        // public HttpPostedFileBase ImageUpload { get; set; }
        //public byte[] ImageUpload { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public CourseView Course { get; set; }


    }
}
