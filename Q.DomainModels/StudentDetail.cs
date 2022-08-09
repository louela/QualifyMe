using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.DomainModels
{
    public class StudentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentDetailID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public string StudentGender { get; set; }
        public string StudentAddress { get; set; }
        public string StudentMobile { get; set; }
        public DateTime StudentBirthday { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }
        [ForeignKey("UserID")]
        public Student Student { get; set; }

    }
}
