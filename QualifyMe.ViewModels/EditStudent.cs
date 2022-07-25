using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class EditStudent
    {
        public int UserID { get; set; }
        public int StudentID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string StudentName { get; set; }
        [Required]
        public string StudentCourse { get; set; }

        [Required]
        public string StudentMobile { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }

    }
}
