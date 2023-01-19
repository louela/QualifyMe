using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace QualifyMe.ViewModels
{
    
public class NewApplicant
    {

        [Required]
        public string ApplicantPurpose { get; set; }

        [Required]
        public DateTime ApplicantDateAndTime { get; set; }
        [Required]
        public string ApplicantResume { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int JobID { get; set; }


        public int ApplicantStatus { get; set; }

        //[Required]//public int ApplicantsCount { get; set; }
    }


}
