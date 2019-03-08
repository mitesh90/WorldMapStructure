using CommonServiceLocator;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;
using Unity.ServiceLocation;
using WorldMap.MVC.CityDataServiceReference;
using WorldMap.MVC.ContinentDataServiceReference;
using WorldMap.MVC.CountryDataServiceReference;
using WorldMap.MVC.OverseasTerritoriesDataServiceReference;
using WorldMap.MVC.RoleDataServiceReference;
using WorldMap.MVC.StateDataServiceReference;
using WorldMap.MVC.UserDataServiceReference;
using WorldMap.MVC.UserRoleMappingServiceReference;

namespace WorldMap.MVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void Initialize()
        {
            // Initialize the application-wide Unity IOC container
            var container = BuildUnityContainer();

            // Setup a direct reference to the unity container using the UnityServiceLocator.
            // This allows for direct resolution of instance, not through constructor injection.
            // Example: ServiceLocator.Current.GetInstance<InterfaceA>(), returns mapped instance of 'InterfaceA'.
            UnityServiceLocator serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            //Set dependency resolver that will handle constructor injection.
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // Register type mappings to be resolved.
            RegisterTypeMappings(container);

            return container;
        }

        public static void RegisterTypeMappings(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IContinentDataService, ContinentDataServiceClient>(
               new HierarchicalLifetimeManager(),
               new InjectionConstructor());

            container.RegisterType<ICityDataService, CityDataServiceClient>(
              new HierarchicalLifetimeManager(),
              new InjectionConstructor());

            container.RegisterType<ICountryDataService, CountryDataServiceClient>(
              new HierarchicalLifetimeManager(),
              new InjectionConstructor());

            container.RegisterType<IOverseasTerritoriesDataService, OverseasTerritoriesDataServiceClient>(
              new HierarchicalLifetimeManager(),
              new InjectionConstructor());

            container.RegisterType<IStateDataService, StateDataServiceClient>(
              new HierarchicalLifetimeManager(),
              new InjectionConstructor());

            container.RegisterType<IRoleDataService, RoleDataServiceClient>(
              new HierarchicalLifetimeManager(),
              new InjectionConstructor());

            container.RegisterType<IUserDataService, UserDataServiceClient>(
              new HierarchicalLifetimeManager(),
              new InjectionConstructor());

            container.RegisterType<IUserRoleMappingService, UserRoleMappingServiceClient>(
              new HierarchicalLifetimeManager(),
              new InjectionConstructor());
        }
    }
}