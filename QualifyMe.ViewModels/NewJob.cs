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
        public string JobTypes { get; set; }
        [Required]
        public string JobStatus { get; set; }

        [Required]
        public int CompanyID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

       
        public int ApplicantID { get; set; }

        [Required]
        public int ApplicantsCount { get; set; }

      
    }
}
