using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QualifyMe.ViewModels
{
    public class StudentView
    {
        public int UserID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string StudentLastName { get; set; }
        public string StudentFirstName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Resume { get; set; }
    
       
        public bool IsAdmin { get; set; }
      //  public string ImagePath { get; set; }
       // public HttpPostedFileBase ImageUpload { get; set; }
        public CourseView Course { get; set; }
        //public virtual List<SkillView> Skills { get; set; }
      
    }
}
