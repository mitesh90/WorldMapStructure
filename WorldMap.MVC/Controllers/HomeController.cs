using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldMap.MVC.ContinentDataServiceReference;
using System.Data.Entity;

namespace WorldMap.MVC.Controllers
{
    public class HomeController : BaseController
    {
        IContinentDataService _continentDataService;
        //ICountryDataService _countryDataService;

        // GET: Home
        public ActionResult Index()
        {
            IContinentDataService _helloService;
            //_helloService = ServiceLocator.Current.GetInstance<IContinentDataService>();
            //var str1 = _helloService.SelectAll();

            var str = _continentDataService.SelectAll();
            //var str1 = _countryDataService.SelectAll();
            return View();
        }

        public HomeController(IContinentDataService continentDataService)
        {
            _continentDataService = continentDataService;
            //_countryDataService = countryDataService;
        }

    }
}