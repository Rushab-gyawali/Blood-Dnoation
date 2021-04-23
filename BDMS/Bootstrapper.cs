using System.Web.Mvc;
using BDMS.Business.Business.Common;
using BDMS.Business.Business.Designation;
using BDMS.Business.Business.Donor;
using BDMS.Business.Business.Error;
using BDMS.Business.Business.Staff;
using BDMS.Repository.Repository.Designation;
using BDMS.Repository.Repository.Donor;
using BDMS.Repository.Repository.Staff;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace BDMS
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();  
            container.RegisterType<ICommonBusiness, CommonBusiness>();
            container.RegisterType<IErrorBusiness, ErrorBusiness>();
            container.RegisterType<IDonorRepository, DonorRepository>();
            container.RegisterType<IDonorBusiness, DonorBusiness>();
            container.RegisterType<IStaffBusiness, StaffBusiness>();
            container.RegisterType<IStaffRepository, StaffRepository>();
            container.RegisterType<IDesignationBusiness, DesignationBusiness>();
            container.RegisterType<IDesignationRepository, DesignationRepository>();


            return container;
        }
    }
}