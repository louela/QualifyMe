﻿using System;
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
        public string ApplicantQuestion { get; set; }

        [Required]
        public DateTime ApplicantDateAndTime { get; set; }

       

        [Required]
        public int UserID { get; set; }

        [Required]
        public int JobID { get; set; }
     

       

        //[Required]
        //public int ApplicantsCount { get; set; }
    }
}
