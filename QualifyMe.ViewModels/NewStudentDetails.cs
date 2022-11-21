using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
     public class NewStudentDetails
    {
        [Required]
        public string StudentGender { get; set; }
        [Required]
        public DateTime StudentBirthday { get; set; }
        [Required]
        public string StudentAddress { get; set; }

        [Required]
        public int CourseID { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}
