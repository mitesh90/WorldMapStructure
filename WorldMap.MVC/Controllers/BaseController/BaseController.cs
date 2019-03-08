using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldMap.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        public ActionResult BaseIndex()
        {
            return View();
        }
    }
}