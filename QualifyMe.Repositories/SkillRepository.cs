using Q.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.Repositories
{
    public interface ISkillRepository
    {
        void InsertSkill(StudentSkillSet s);

        List<StudentSkillSet> GetSkillsByUserID(int UserID);
        List<StudentSkillSet> GetStudentSkillSetsBySkillName(string SkillName);
        List<StudentSkillSet> GetSkills();

    }
    public class SkillRepository : ISkillRepository
    {
        QualifyMeDbContext db;
        IStudentsRepository sr;
        public SkillRepository()
        {
            db = new QualifyMeDbContext();
            sr = new StudentsRepository();
           
        }
        public void InsertSkill(StudentSkillSet s)
        {
           
               db.StudentSkillSets.Add(s);
                db.SaveChanges();
            
     
        }
        public List<StudentSkillSet> GetSkills()
        {
            List<StudentSkillSet> jb = db.StudentSkillSets.OrderByDescending(temp => temp.UserID).ToList();
            return jb;
        }

        public List<StudentSkillSet> GetSkillsByUserID(int UserID)
        {
            List<StudentSkillSet> sk = db.StudentSkillSets.Where(temp => temp.UserID == UserID).ToList();
            return sk;
        }

        public List<StudentSkillSet> GetStudentSkillSetsBySkillName(string SkillName) { List<StudentSkillSet> ta = db.StudentSkillSets.Where(temp => temp.SkillName == SkillName).ToList(); return ta; }
    }

  
}
