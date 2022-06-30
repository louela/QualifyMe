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
        void InsertApplicant(NewApplicant avm);
        void DeleteApplicant(int aid);
        List<ApplicantView> GetApplicantsByQJobID(int jid);
        ApplicantView GetApplicantByApplicantID(int ApplicantID);
    }
    public class ApplicantsService : IApplicantsService
    {
        IApplicantsRepository ar;

        public ApplicantsService()
        {
            ar = new ApplicantsRepository();
        }
        public void InsertApplicant(NewApplicant avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewApplicant, Applicant>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Applicant a = mapper.Map<NewApplicant, Applicant>(avm);
            ar.InsertApplicant(a);
        }

        public void DeleteApplicant(int aid)
        {
            ar.DeleteApplicant(aid);
        }

        public List<ApplicantView> GetApplicantsByQJobID(int jid)
        {
            List<Applicant> a = ar.GetApplicantsByJobID(jid);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant,ApplicantView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<ApplicantView> avm = mapper.Map<List<Applicant>, List<ApplicantView>>(a);
            return avm;
        }

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
    }
}
