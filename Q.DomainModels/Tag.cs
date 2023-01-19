using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.DomainModels
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagID { get; set; }
        public string TagName { get; set; }
        public int JobID { get; set; }


        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }

    }
}
