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
        public int CourseID { get; set; }
      
        public string ApplicantQuestion { get; set; }
        public string ApplicantGender { get; set; }
        public string ApplicantAddress { get; set; }
        public DateTime ApplicantBirthday { get; set; }


        [ForeignKey("CourseID")]
        public  Course Course { get; set; }

        [ForeignKey("UserID")]
        public Student Student { get; set; }

        [ForeignKey("JobID")]
        public  Job Job { get; set; }

        public virtual List<Student> Students { get; set; }


    }
}

