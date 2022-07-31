using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace QualifyMe.Repositories
{
    public interface IStudentsRepository
    {
        void InsertStudent(Student s);
        void UpdateStudentDetails(Student s);
        void UpdateStudentPassword(Student s);
        void DeleteStudent(int sid);
        List<Student> GetStudents();
        List<Student> GetStudentsByEmailAndPassword(string Email, string Password);
        List<Student> GetStudentsByEmail(string Email);
        List<Student> GetStudentsByUserID(int UserID);
        int GetLatestStudentID();
    }
    public class StudentsRepository : IStudentsRepository
    {
        QualifyMeDbContext db;

        public StudentsRepository()
        {
            db = new QualifyMeDbContext();
        }

        public void InsertStudent(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
        }

        public void UpdateStudentDetails(Student s)
        {
            Student st = db.Students.Where(temp => temp.UserID == s.UserID).FirstOrDefault();
            if (st != null)
            {
                st.StudentName = s.StudentName;
                st.StudentMobile = s.StudentMobile;

                db.SaveChanges();
            }
        }

        public void UpdateStudentPassword(Student s)
        {
            Student st = db.Students.Where(temp => temp.UserID == s.UserID).FirstOrDefault();
            if (st != null)
            {
                st.Password = s.Password;
                db.SaveChanges();
            }
        }

        public void DeleteStudent(int sid)
        {
            Student st = db.Students.Where(temp => temp.UserID == sid).FirstOrDefault();
            if (st != null)
            {
                db.Students.Remove(st);
                db.SaveChanges();
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> st = db.Students.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.StudentName).ToList();
            return st;
        }

        public List<Student> GetStudentsByEmailAndPassword(string Email, string Password)
        {
            List<Student> st = db.Students.Where(temp => temp.Email == Email && temp.Password == Password).ToList();
            return st;
        }

        public List<Student> GetStudentsByEmail(string Email)
        {
            List<Student> st = db.Students.Where(temp => temp.Email == Email).ToList();
            return st;
        }

        public List<Student> GetStudentsByUserID(int UserID)
        {
            List<Student> st = db.Students.Where(temp => temp.UserID == UserID).ToList();
            return st;
        }

        public int GetLatestStudentID()
        {
            int sid = db.Students.Select(temp => temp.UserID).Max();
            return sid;
        }
    }
}
