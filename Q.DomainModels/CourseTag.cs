using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.DomainModels
{
    public class CourseTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CourseTagID { get; set; }
        public int CourseID { get; set; }
        public int JobID { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }
    }
}
