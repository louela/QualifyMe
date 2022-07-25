using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace Q.DomainModels
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobQualification { get; set; }
        public string JobTypes { get; set; }
        public string JobStatus { get; set; }
        public DateTime JobDateAndTime { get; set; }
        public int? DepartmentID { get; set; }
       // public int? CourseID { get; set; }

        public int? CompanyID { get; set; }
      
        public int ApplicantsCount { get; set; }
       // public int? ApplicantID { get; set; }




        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        //[ForeignKey("ApplicantID")]
        //public virtual Applicant Applicant { get; set; }

        public virtual List<Applicant> Applicants { get; set; }
    }
}
