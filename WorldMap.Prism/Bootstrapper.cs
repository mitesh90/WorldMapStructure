using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System.Windows;
//using WorldMap.ServiceDemo;
using WorldMap.WorldNavigation;
using WorldMap.WorldInfo;
using WorldMap.Prism.CountryDataServiceReference;

namespace WorldMap.Prism
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            //moduleCatalog.AddModule(typeof(EmployeeModule));
            moduleCatalog.AddModule(typeof(NavigationModule));
            moduleCatalog.AddModule(typeof(WorldModule), InitializationMode.OnDemand);
            moduleCatalog.AddModule(typeof(Geometry2DTo3DModule), InitializationMode.OnDemand);
            //moduleCatalog.AddModule(typeof(EmployeeModule), InitializationMode.OnDemand);
            //moduleCatalog.AddModule(typeof(HardwareModule), InitializationMode.OnDemand);
            //moduleCatalog.AddModule(typeof(RequestModule), InitializationMode.OnDemand);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            //Container.RegisterType<DepartmentServiceReference.IDepartment, DepartmentServiceReference.Department>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<DepartmentServiceReference.IDepartment, DepartmentServiceReference.DepartmentClient>();

            //Container.RegisterType<ICityDataService, CityDataService>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<ICountryDataService, CountryDataServiceClient>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IContinentDataService, ContinentDataServiceClient>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IOverseasTerritoriesDataService, OverseasTerritoriesDataService>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IStateDataService, StateDataService>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IRoleDataService, RoleDataService>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IUserDataService, UserDataService>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IUserRoleMappingService, UserRoleMappingService>(new ContainerControlledLifetimeManager());

            //base.ConfigureContainer();
            //RegisterTypeIfMissing(typeof(ICountryDataService), typeof(CountryDataServiceClient), true);
            
            ///base.ConfigureContainer();

            //ICountryDataService df  = this.Container.Resolve<ICountryDataService>();
            //RegisterTypeIfMissing(typeof(ICountryDataService), typeof(CountryDataServiceClient),true);
            //Container.RegisterType<ICountryDataService, CountryDataServiceClient>(new ContainerControlledLifetimeManager());
        }
    }
}
