using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Q.DomainModels
{
    public partial class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }    
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        //public string Resume { get; set; }
       // public HttpPostedFileBase file { get; set; }
     
        public bool IsAdmin { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        public virtual List<SkillSet> Skill { get; set; }
    }
}
