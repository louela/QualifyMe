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
    public class Applicant
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicantID { get; set; }
        public DateTime ApplicantDateAndTime { get; set; }
        public int UserID { get; set; }
        public int JobID { get; set; }
        public int ApplicantsCount { get; set; }
        public string ApplicantPurpose { get; set; }
        

        [ForeignKey("UserID")]
        public virtual Student Student{ get; set; }

        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }


    }
}

