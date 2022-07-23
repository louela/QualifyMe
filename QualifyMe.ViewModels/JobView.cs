using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class JobView
    {
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobQualification  { get; set; }
        public string JobTypes { get; set; }
        public string JobStatus { get; set; }
        public DateTime JobDateAndTime { get; set; }
        public int CompanyID { get; set; }
        public int CourseID { get; set; }
        public int ApplicantsCount { get; set; }
       // public int ApplicantID { get; set; }

        public CompanyView Company { get; set; }
        public CourseView Course { get; set; }
        //public ApplicantView Applicant { get; set; }
        //public virtual List<ApplicantView> Applicants { get; set; }
    }
}
