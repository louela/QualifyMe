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
    public interface IApplicantsService
    {
        int InsertApplicant(NewApplicant avm);
        void DeleteApplicant(int aid);
        ApplicantView GetApplicantByApplicantID(int ApplicantID);

        List<ApplicantView> GetJobsByUserID(int UserID);
        List<ApplicantView> GetApplicantsByJobID(int JobID);
        List<ApplicantView> GetApplicantsByCompanyID(int CompanyID);
    }
    public class ApplicantsService : IApplicantsService
    {
        IApplicantsRepository ar;

        public ApplicantsService()
        {
            ar = new ApplicantsRepository();
        }
        public int InsertApplicant(NewApplicant avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewApplicant, Applicant>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Applicant a = mapper.Map<NewApplicant, Applicant>(avm);
            ar.InsertApplicant(a);
            int aid = ar.GetLatestApplicantID();
            return aid;
        }

        public void DeleteApplicant(int aid)
        {
            ar.DeleteApplicant(aid);
        }

        //public List<ApplicantView> GetApplicantsByJobID(int jid)
        //{
        //    List<Applicant> a = ar.GetApplicantsByJobID(jid);
        //    var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant,ApplicantView>(); cfg.IgnoreUnmapped(); });
        //    IMapper mapper = config.CreateMapper();
        //    List<ApplicantView> avm = mapper.Map<List<Applicant>, List<ApplicantView>>(a);
        //    return avm;
        //}

        public ApplicantView GetApplicantByApplicantID(int ApplicantID)
        {
            Applicant a = ar.GetApplicantsByApplicantID(ApplicantID).FirstOrDefault();
            ApplicantView avm = null;
            if (a != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant, ApplicantView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                avm = mapper.Map<Applicant, ApplicantView>(a);
            }
            return avm;
        }

        //public ApplicantView GetApplicantsByJobID(int JobID, int uid = 0)
        //{
        //    Applicant a = ar.GetApplicantsByJobID(JobID).FirstOrDefault();
        //    ApplicantView av = null;
        //    if (a != null)
        //    {
        //        var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant, ApplicantView>(); cfg.IgnoreUnmapped(); });
        //        IMapper mapper = config.CreateMapper();
        //        av = mapper.Map<Applicant, ApplicantView>(a);
        //    }
        //    return av;
        //}

        public List<ApplicantView> GetJobsByUserID(int UserID)
        {
            List<Applicant> a = ar.GetJobsByUserID(UserID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant, ApplicantView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<ApplicantView> avm = mapper.Map<List<Applicant>, List<ApplicantView>>(a);
            return avm;
        }

        public List<ApplicantView> GetApplicantsByJobID(int JobID)
        {
            List<Applicant> a = ar.GetApplicantsByJobID(JobID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant, ApplicantView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<ApplicantView> av = mapper.Map<List<Applicant>, List<ApplicantView>>(a);
            return av;
        }

        public List<ApplicantView> GetApplicantsByCompanyID(int CompanyID)
        {
            List<Applicant> a = ar.GetApplicantsByCompanyID(CompanyID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant, ApplicantView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<ApplicantView> av = mapper.Map<List<Applicant>, List<ApplicantView>>(a);
            return av;
        }
    }
}
