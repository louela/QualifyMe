using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class ApplicantView
    {
        public int ApplicantID { get; set; }
        public string ApplicantPurpose { get; set; }
        public DateTime ApplicantDateAndTime { get; set; }
        public int UserID { get; set; }
        public int JobID { get; set; }
        public int ApplicantsCount { get; set; }
        public virtual StudentView Student { get; set; }
        public virtual List<ApplicantView> Applicants { get; set; }
    }
}
