using Q.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QualifyMe.ViewModels
{
    public class EditStudent
    {
        public int UserID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string StudentFirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string StudentLastName { get; set; }
        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Mobile { get;set; }
        public string Resume { get; set; }
        public HttpPostedFileBase file { get; set; }
        //[Required]
        //public string ImagePath { get; set; }
        //[Required]
        //public HttpPostedFileBase ImageUpload { get; set; }

        public Course Course { get; set; }
      
        

        

    }
}
