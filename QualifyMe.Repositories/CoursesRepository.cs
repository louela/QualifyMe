using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace QualifyMe.Repositories
{
    public interface ICoursesRepository
    {
        void InsertCourse(Course c);
        void UpdateCourse(Course c);
        void DeleteCourse(int cid);
        List<Course> GetCourses();
        int GetLatestCourseID();
        List<Course> GetCoursesByCourseName(string CourseName);
        List<Course> GetCoursesByCourseID(int CourseID);
    }
    public class CoursesRepository : ICoursesRepository
    {
        QualifyMeDbContext db;
        IApplicantsRepository ar;

        public CoursesRepository()
        {
            db = new QualifyMeDbContext();
            ar = new ApplicantsRepository();
        }
        public void InsertCourse(Course c)
        {
            db.Courses.Add(c);
            db.SaveChanges();
            
        }

        public void UpdateCourse(Course c)
        {
            Course co = db.Courses.Where(temp => temp.CourseID == c.CourseID).FirstOrDefault();
            if (co != null)
            {
                co.CourseName = c.CourseName;
                db.SaveChanges();
            }
        }

       

        public void DeleteCourse(int cid)
        {
            Course co = db.Courses.Where(temp => temp.CourseID == cid).FirstOrDefault();
            if (co != null)
            {
                db.Courses.Remove(co);
                db.SaveChanges();

            }
        }

        public List<Course> GetCourses()
        {
            List<Course> co = db.Courses.OrderByDescending(temp => temp.CourseName).ToList();
            return co;
        }

        public int GetLatestCourseID()
        {
            int cid = db.Courses.Select(temp => temp.CourseID).Max();
            return cid;
        }

        public List<Course> GetCoursesByCourseName(string CourseName)
        {
            List<Course> co = db.Courses.Where(temp => temp.CourseName == CourseName).ToList();
            return co;
        }


        public List<Course> GetCoursesByCourseID(int CourseID)
        {
            List<Course> co = db.Courses.Where(temp => temp.CourseID == CourseID).ToList();
            return co;
        }
    }
}
