using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class AddCourseView
    {
        
        [RegularExpression(@"^[a-zA-Z ]*$")]
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}



