﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace QualifyMe.Repositories
{
    public interface IApplicantsRepository
    {
        void InsertApplicant(Applicant a);
       
        void DeleteApplicant(int aid);
        int GetLatestApplicantID();
       
        List<Applicant> GetApplicantsByApplicantID(int ApplicantID);
        List<Applicant> GetApplicantsByJobID(int JobID);

        //Applicant GetJob (int JobID);
        int GetLatestJobID(int JobID);
        //void UpdateApplicantsCount(int aid, int value);

    }
    public class ApplicantsRepository : IApplicantsRepository
    {
        QualifyMeDbContext db;
        IJobsRepository jr;
        

        public ApplicantsRepository()
        {
            db = new QualifyMeDbContext();
            jr = new JobsRepository();
           
        }

        public void InsertApplicant(Applicant a)
        {
            db.Applicants.Add(a);
            db.SaveChanges();
            //jr.UpdateApplicantsCount(a.JobID, 1);
        }


        public void DeleteApplicant(int aid)
        {
            Applicant ap = db.Applicants.Where(temp => temp.ApplicantID == aid).First();
            if (ap != null)
            {
                db.Applicants.Remove(ap);
                db.SaveChanges();
                //jr.UpdateApplicantsCount(ap.JobID, -1);
            }
        }

        public List<Applicant> GetApplicantsByJobID(int JobID)
        {
            List<Applicant> ap = db.Applicants.Where(temp => temp.JobID == JobID).OrderByDescending(temp => temp.ApplicantDateAndTime).ToList();
            return ap;
        }

        public List<Applicant> GetApplicantsByApplicantID(int ApplicantID)
        {
            List<Applicant> ap = db.Applicants.Where(temp => temp.ApplicantID == ApplicantID).ToList();
            return ap;
        }

        public int GetLatestApplicantID()
        {
            int aid = db.Applicants.Select(temp => temp.ApplicantID).Max();
            return aid;
        }

        public int GetLatestJobID(int JobID)
        {
            int jid = db.Jobs.Select(temp => temp.JobID).Max();
            return jid;
        }

        //public void UpdateApplicantsCount(int aid,int value)
        //{
        //    Applicant a = db.Applicants.FirstOrDefault(temp => temp.ApplicantID == aid);
        //    if(a!= null)
        //    {
        //        a.Applicant +=  value;
        //        db.SaveChanges();
        //    }
        //}
    }
}
