using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.ServiceDemoHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ServiceDemo.CountryDataService)))
            {
                host.Open();
                Console.WriteLine("Continent Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }

            //List<ServiceHost> lstServiceHot = new List<ServiceHost>();

            //lstServiceHot.Add(new ServiceHost(typeof(ServiceDemo.CityDataService)));
            //lstServiceHot.Add(new ServiceHost(typeof(ServiceDemo.CountryDataService)));
            //lstServiceHot.Add(new ServiceHost(typeof(ServiceDemo.ContinentDataService)));
            //lstServiceHot.Add(new ServiceHost(typeof(ServiceDemo.OverseasTerritoriesDataService)));
            //lstServiceHot.Add(new ServiceHost(typeof(ServiceDemo.StateDataService)));
            //lstServiceHot.Add(new ServiceHost(typeof(ServiceDemo.RoleDataService)));
            //lstServiceHot.Add(new ServiceHost(typeof(ServiceDemo.UserDataService)));
            //lstServiceHot.Add(new ServiceHost(typeof(ServiceDemo.UserRoleMappingService)));

            //foreach (var host in lstServiceHot)
            //{
            //    host.Open();
            //    Console.WriteLine("Employee Host started @ " + DateTime.Now.ToString());
            //    host.Close();
            //}

            //Console.ReadLine();
        }
    }
}
