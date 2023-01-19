using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace QualifyMe.Repositories
{
    public interface ITagsRepository
    {
        void InsertTag(Tag t);
        void UpdateTag(Tag t);
        void DeleteTag(int cid);
        List<Tag> GetTags();
        int GetLatestTagID();
        List<Tag> GetTagsByTagName(string TagName);
        List<Tag> GetTagsByTagID(int TagID);
        //List<Course> GetCoursesByDepartmentName(string DepartmentName);
        List<Tag> GetTagsByJobID(int JobID);
    }
    public class TagsRepository : ITagsRepository
    {
        QualifyMeDbContext db;
        IJobsRepository jr;

        public TagsRepository()
        {
            db = new QualifyMeDbContext();
            jr = new JobsRepository();

        }


        public void InsertTag(Tag t)
        {
            db.Tags.Add(t);
            db.SaveChanges();
            ////int id = t.JobID;
        }

        public void UpdateTag(Tag t)
        {
            Tag ta = db.Tags.Where(temp => temp.TagID == t.TagID).FirstOrDefault();
            if (ta != null)
            {
                ta.TagName = t.TagName;
                db.SaveChanges();
            }
        }

        public void DeleteTag(int cid)
        {
            Tag ta = db.Tags.Where(temp => temp.TagID == cid).FirstOrDefault();
            if (ta != null)
            {
                db.Tags.Remove(ta);
                db.SaveChanges();

            }
        }

        public List<Tag> GetTags()
        {
            List<Tag> ta = db.Tags.OrderByDescending(temp => temp.TagName).ToList();
            return ta;
        }

        public int GetLatestTagID()
        {
            int cid = db.Tags.Select(temp => temp.TagID).Max();
            return cid;
        }

        public List<Tag> GetTagsByTagName(string TagName)
        {
            List<Tag> ta = db.Tags.Where(temp => temp.TagName == TagName).ToList();
            return ta;
        }

        public List<Tag> GetTagsByTagID(int TagID)
        {
            List<Tag> ta = db.Tags.Where(temp => temp.TagID == TagID).ToList();
            return ta;
        }

        public List<Tag> GetTagsByJobID(int JobID)
        {
            List<Tag> ta = db.Tags.Where(temp => temp.JobID == JobID).ToList();
            return ta;
        }
    }
}
