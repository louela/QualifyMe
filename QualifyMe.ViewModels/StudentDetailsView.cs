using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class StudentDetailsView
    {
        public int StudentDetailID { get; set; }
        public string StudentGender { get; set; }
        public DateTime StudentBirthday { get; set; }
        public string StudentAddress { get; set; }
        public string StudentMobile { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }

        public StudentView Student { get; set; }
        public CourseView Course { get; set; }
    }
}
