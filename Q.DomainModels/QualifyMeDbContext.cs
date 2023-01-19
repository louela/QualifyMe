using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.DomainModels
{
   public class QualifyMeDbContext : DbContext
    {
       
        public DbSet<Student> Students { get; set; }
        //public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<StudentSkillSet> StudentSkillSets { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SkillTag> SkillTags { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
    }
}
