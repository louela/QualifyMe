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
    public interface ITagsService
    {
        void InsertTag(AddTagView atv);
        void UpdateTag(TagView atv);
        void DeleteTag(int cid);
        List<TagView> GetTags();
        TagView GetTagByTagName(string TagName);

        TagView GetTagByTagID(int TagID, int tid);
        TagView GetTagByJobID(int JobID, int cid);

    }
    public class TagsService : ITagsService
    {
        ITagsRepository tr;

        public TagsService()
        {
            tr = new TagsRepository();
        }

        public void InsertTag(AddTagView atv)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AddTagView, Tag>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Tag t = mapper.Map<AddTagView, Tag>(atv);
            tr.InsertTag(t);
        }

        public void UpdateTag(TagView atv)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TagView, Tag>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Tag t = mapper.Map<TagView, Tag>(atv);
            tr.UpdateTag(t);
        }

        public void DeleteTag(int cid)
        {
            tr.DeleteTag(cid);
        }
        public TagView GetTagByTagName(string TagName)
        {
            Tag t = tr.GetTagsByTagName(TagName).FirstOrDefault(); TagView cvm = null; if (t != null) { var config = new MapperConfiguration(cfg => { cfg.CreateMap<Tag, TagView>(); cfg.IgnoreUnmapped(); }); IMapper mapper = config.CreateMapper(); cvm = mapper.Map<Tag, TagView>(t); }
            return cvm;
        }
        public List<TagView> GetTags()
        {
            List<Tag> t = tr.GetTags();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Tag, TagView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<TagView> cvm = mapper.Map<List<Tag>, List<TagView>>(t);
            return cvm;
        }

        public TagView GetTagByTagID(int TagID, int tid=0)
        {
            Tag t = tr.GetTagsByTagID(TagID).FirstOrDefault();
            TagView cvm = null;
            if (t != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Tag, TagView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<Tag, TagView>(t);

            }
            return cvm;
        }

        public TagView GetTagByJobID(int JobID, int cid=0)
        {
            Tag t = tr.GetTagsByJobID(JobID).FirstOrDefault();
            TagView cvm = null;
            if (t != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Tag, TagView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<Tag, TagView>(t);
            }
            return cvm;
        }
    }
}
