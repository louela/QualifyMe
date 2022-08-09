using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace QualifyMe.Repositories
{
    public interface ICompaniesRepository
    {
        void InsertCompany(Company c);
        void UpdateCompanyDetails(Company c);
        void UpdateCompanyStatus(Company c);
        void UpdateCompanyPassword(Company c);
        void DeleteCompany(int cid);
        List<Company> GetCompanies();
        List<Company> GetCompaniesByEmailAndPassword(string Email, string Password);
        List<Company> GetCompaniesByEmail(string Email);
        List<Company> GetCompaniesByCompanyName(string CompanyName);
        List<Company> GetCompaniesByCompanyID(int CompanyID);
        int GetLatestCompanyID();
    }
    public class CompaniesRepository : ICompaniesRepository
    {
        QualifyMeDbContext db;
        public CompaniesRepository()
        {
            db = new QualifyMeDbContext();
        }
        public void InsertCompany(Company c)
        {
            db.Companies.Add(c);
            db.SaveChanges();
        }

        public void UpdateCompanyDetails(Company c)
        {
            Company cu = db.Companies.Where(temp => temp.CompanyID == c.CompanyID).FirstOrDefault();
            if (cu != null)
            {
                cu.CompanyName = c.CompanyName;
                cu.CompanyMobile = c.CompanyMobile;
                cu.CompanyAddress = c.CompanyAddress;
                cu.CompanyDescription = c.CompanyDescription;
                db.SaveChanges();

            }
        }

        public void UpdateCompanyStatus(Company c)
        {
            Company cu = db.Companies.Where(temp => temp.CompanyID == c.CompanyID).FirstOrDefault();
            if (cu != null)
            {
                cu.CompanyName = c.CompanyName;
                cu.Email = c.Email;
                cu.IsApproved = c.IsApproved;
                db.SaveChanges();

            }
        }

        public void UpdateCompanyPassword(Company c)
        {
            Company cu = db.Companies.Where(temp => temp.CompanyID== c.CompanyID).FirstOrDefault();
            if (cu != null)
            {
                cu.Password = c.Password;
                db.SaveChanges();

            }
        }

        public void DeleteCompany(int cid)
        {
            Company cu = db.Companies.Where(temp => temp.CompanyID == cid).FirstOrDefault();
            if (cu != null)
            {
                db.Companies.Remove(cu);
                db.SaveChanges();

            }
        }

        public List<Company> GetCompanies()
        {
            List<Company> cu = db.Companies.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.CompanyName).ToList();
            return cu;
        }

        public List<Company> GetCompaniesByEmailAndPassword(string CompanyEmail, string Password)
        {
            List<Company> cu = db.Companies.Where(temp => temp.Email == CompanyEmail && temp.Password == Password).ToList();
            return cu;
        }

        public List<Company> GetCompaniesByEmail(string Email)
        {
            List<Company> cu = db.Companies.Where(temp => temp.Email == Email).ToList();
            return cu;
        }

        public List<Company> GetCompaniesByCompanyName(string CompanyName)
        {
            List<Company> cu = db.Companies.Where(temp => temp.CompanyName == CompanyName).ToList();
            return cu;
        }

        public List<Company> GetCompaniesByCompanyID(int CompanyID)
        {
            List<Company> cu = db.Companies.Where(temp => temp.CompanyID == CompanyID).ToList();
            return cu;
        }

        public int GetLatestCompanyID()
        {
            int cid = db.Companies.Select(temp => temp.CompanyID).Max();
            return cid;
        }
    }
}
