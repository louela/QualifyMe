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
    public interface IDepartmentsService
    {
        int InsertDepartment(AddDepartmentView dvm);
        void UpdateDepartment(DepartmentView dvm);
        void DeleteDepartment(int did);
        List<DepartmentView> GetDepartments();
        DepartmentView GetDepartmentByDepartmentID(int DepartmentID);
    }

    public class DepartmentsService : IDepartmentsService
    {
        IDepartmentsRepository dr;

        public DepartmentsService()
        {
            dr = new DepartmentsRepository();
        }
        public int InsertDepartment(AddDepartmentView dvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AddDepartmentView, Department>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Department d = mapper.Map<AddDepartmentView, Department>(dvm);
            dr.InsertDepartment(d);
            int did = dr.GetLatestDepartmentID();
            return did;
        }

        public void UpdateDepartment(DepartmentView dvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<DepartmentView, Department>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Department d = mapper.Map<DepartmentView, Department>(dvm);
            dr.UpdateDepartment(d);
        }

        public void DeleteDepartment(int did)
        {
            dr.DeleteDepartment(did);
        }

        public List<DepartmentView> GetDepartments()
        {
            List<Department> d = dr.GetDepartments();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Department, DepartmentView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<DepartmentView> dvm = mapper.Map<List<Department>, List<DepartmentView>>(d);
            return dvm;
        }

        public DepartmentView GetDepartmentByDepartmentID(int DepartmentID)
        {
            Department d = dr.GetDepartmentsByDepartmentID(DepartmentID).FirstOrDefault();
            DepartmentView dvm = null;
            if (d != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Department, DepartmentView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                dvm = mapper.Map<Department, DepartmentView>(d);


            }
            return dvm;
        }


    }
}

