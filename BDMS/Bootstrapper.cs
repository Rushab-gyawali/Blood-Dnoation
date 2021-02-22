using BDMS.Business.Business.Common;
using BDMS.Business.Business.Donor;
using BDMS.Repository.Repository.Donor;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace BDMS.Web
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
            container.RegisterType<IDonorBusiness, DonorBusiness>();
            container.RegisterType<IDonorRepository, DonorRepository>();
           


            return container;
        }
    }
}