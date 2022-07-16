using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class NewJob
    {

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public DateTime JobDateAndTime { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public string JobQualification { get; set; }
        [Required]
        public String JobTypes { get; set; }
        [Required]
        public String JobStatus { get; set; }

        [Required]
        public int CompanyID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public int ApplicantsCount { get; set; }

      
    }
}
