using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace QualifyMe.Repositories
{
    public interface IDepartmentsRepository
    {
        void InsertDepartment(Department d);
        void UpdateDepartment(Department d);
        void DeleteDepartment(int did);
        List<Department> GetDepartments();
        int GetLatestDepartmentID();
        List<Department> GetDepartmentsByDepartmentName(string DepartmentName);
        List<Department> GetDepartmentsByDepartmentID(int DepartmentID);
    }

    public class DepartmentsRepository: IDepartmentsRepository
    {
        QualifyMeDbContext db;
        

        public DepartmentsRepository()
        {
            db = new QualifyMeDbContext();
           
        }
        public void InsertDepartment(Department d)
        {
            db.Departments.Add(d);
            db.SaveChanges();
        }

        public void UpdateDepartment(Department d)
        {
            Department de = db.Departments.Where(temp => temp.DepartmentID == d.DepartmentID).FirstOrDefault();
            if (de != null)
            {
                de.DepartmentName = d.DepartmentName;
                db.SaveChanges();
            }
        }

        public void DeleteDepartment(int did)
        {
            Department de = db.Departments.Where(temp => temp.DepartmentID == did).FirstOrDefault();
            if (de != null)
            {
                db.Departments.Remove(de);
                db.SaveChanges();

            }
        }

        public List<Department> GetDepartments()
        {
            List<Department> de = db.Departments.OrderByDescending(temp => temp.DepartmentName).ToList();
            return de;
        }

        public int GetLatestDepartmentID()
        {
            int did = db.Departments.Select(temp => temp.DepartmentID).Max();
            return did;
        }

        public List<Department> GetDepartmentsByDepartmentName(string DepartmentName)
        {
            List<Department> de = db.Departments.Where(temp => temp.DepartmentName == DepartmentName).ToList();
            return de;
        }

        public List<Department> GetDepartmentsByDepartmentID(int DepartmentID)
        {
            List<Department> de = db.Departments.Where(temp => temp.DepartmentID == DepartmentID).ToList();
            return de;
        }
        
    }
}
