using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.DomainModels
{
    public class JobCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobCategoryID { get; set; }
        public int JobID    { get; set; }
        public int DepartmentID { get; set; }
        public int CourseID { get; set; }

        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

    }
}
