using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLibrary.WebHost.Controllers
{
    //Controller conventions
    //1. Public class
    //2. Derive from Controller
    //3. Name must end with 'Controller'
    //4. Must be in MVC assembly
    //5. Must be unique based upon name only
    public class HomeController : Controller
    {
        //Action
        //1. Public method
        //2. Must return ActionResult or a derived type
        public ActionResult Index()
        {
            return View(); //return View ("Index");
        }

        public ActionResult About () => View();
       
    }
}