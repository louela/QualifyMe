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
        public string ApplicantQPurpose{ get; set; }
        public string ApplicantGender { get; set; }
        public string ApplicantAddress { get; set; }
        public DateTime ApplicantBirthday { get; set; }
        public DateTime ApplicantDateAndTime { get; set; }
      
        public int UserID { get; set; }
        public int JobID { get; set; }
        public int CourseID { get; set; }
       
        public int ApplicantsCount { get; set; }
        public StudentView Student { get; set; }
        public JobView Job { get; set; }
        public CourseView Course { get; set; }

        public virtual List<StudentView> Students { get; set; }
    }
}
