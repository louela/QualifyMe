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
        public DateTime JobDateAndTime { get; set; }
        public int? CompanyID { get; set; }
        public int? DepartmentID { get; set; }
        public int ApplicantsCount { get; set; }


        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        public virtual List<Applicant> Applicants { get; set; }
    }
}
