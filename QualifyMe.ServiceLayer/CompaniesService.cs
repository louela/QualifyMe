using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Q.DomainModels;
using QualifyMe.Repositories;
using QualifyMe.ViewModels;

namespace QualifyMe.ServiceLayer
{
    public interface ICompaniesService
    {
        int InsertCompany(CompanyRegister cr);
        void UpdateCompanyDetails(EditCompany ec);
        void UpdateCompanyStatus(EditCompanyStatusView ec);
        void UpdateCompanyPassword(EditPassword ep);
        void DeleteCompany(int cid);
        List<CompanyView> GetCompanies();
        CompanyView GetCompaniesByEmailAndPassword(string Email, string Password);
        CompanyView GetCompaniesByEmail(string Email);
        CompanyView GetCompaniesByCompanyID(int CompanyID);
    }
    public class CompaniesService : ICompaniesService
    {
        ICompaniesRepository ucr;

        public CompaniesService()
        {
            ucr = new CompaniesRepository();
        }
        public int InsertCompany(CompanyRegister cr)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CompanyRegister, Company>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Company u = mapper.Map<CompanyRegister, Company>(cr);
            u.Password = SHA256HashGenerator.GenerateHash(cr.Password);
            ucr.InsertCompany(u);
            int uid = ucr.GetLatestCompanyID();
            return uid;
        }

        public void UpdateCompanyDetails(EditCompany ec)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditCompany, Company>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Company u = mapper.Map<EditCompany, Company>(ec);
            ucr.UpdateCompanyDetails(u);
        }

        public void UpdateCompanyStatus(EditCompanyStatusView ec)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditCompanyStatusView, Company>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Company u = mapper.Map<EditCompanyStatusView, Company>(ec);
            ucr.UpdateCompanyStatus(u);
        }

        public void UpdateCompanyPassword(EditPassword ep)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditPassword, Company>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Company u = mapper.Map<EditPassword, Company>(ep);
            u.Password = SHA256HashGenerator.GenerateHash(ep.Password);
            ucr.UpdateCompanyPassword(u); ;
        }

        public void DeleteCompany(int cid)
        {
            ucr.DeleteCompany(cid);
        }

        public List<CompanyView> GetCompanies()
        {
            List<Company> u = ucr.GetCompanies();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Company, CompanyView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<CompanyView> uvm = mapper.Map<List<Company>, List<CompanyView>>(u);
            return uvm;
        }

        public CompanyView GetCompaniesByEmailAndPassword(string Email, string Password)
        {
            Company u = ucr.GetCompaniesByEmailAndPassword(Email, SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            CompanyView uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Company, CompanyView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Company, CompanyView>(u);
            }
            return uvm;
        }

        public CompanyView GetCompaniesByEmail(string Email)
        {
            Company u = ucr.GetCompaniesByEmail(Email).FirstOrDefault();
            CompanyView uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Company, CompanyView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Company, CompanyView>(u);
            }
            return uvm;
        }

        public CompanyView GetCompaniesByCompanyID(int CompanyID)
        {
            Company u = ucr.GetCompaniesByCompanyID(CompanyID).FirstOrDefault();
            CompanyView uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Company, CompanyView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Company, CompanyView>(u);
            }
            return uvm;
        }
    }
}
