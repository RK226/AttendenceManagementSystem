using BusinessServices.BusinessInterface;
using BusinessServices.BusinessServices;
using Services;
using Services.BusinessServices;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
             container.RegisterType<ICountryMasterServices, CountryServices>();
             container.RegisterType<ICollegeMasterServices, CollegeMasterServices>();
             container.RegisterType<IDistrictMasterServices, DistrictServices>();
             container.RegisterType<IStateMasterServices, StateMasterServices>();
             container.RegisterType<ISectionMasterServices, SectionMasterServices>();
             container.RegisterType<IStandardMasterServices, StandardMasterServices>();
             container.RegisterType<IDepartmentServices, DepartmentServices>();
             container.RegisterType<IBranchMasterServices, BranchMasterServices>();
             container.RegisterType<IDivisionMasterServices, DivisionMasterServices>();
             container.RegisterType<IYearMasterServices, YearMasterServices>();
             container.RegisterType<ISectionMasterServices, SectionMasterServices>();
             container.RegisterType<IStudentServices, StudentServices>();
             container.RegisterType<ISubjectServices, SubjectServices>();
             container.RegisterType<IUserDetailServices, UserDetailServices>();
             container.RegisterType<IAttendenceServices, AttendenceServices>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}