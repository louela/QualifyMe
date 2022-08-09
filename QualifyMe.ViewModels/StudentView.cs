using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class StudentView
    {
        public int UserID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string StudentName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    
       
        public bool IsAdmin { get; set; }

        public CourseView Course { get; set; }
      
    }
}
