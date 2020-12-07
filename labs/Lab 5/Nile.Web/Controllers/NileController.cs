using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nile.Web.Controllers
{
    public class NileController : Controller
    {
        public NileController ()
        {
            //Gets the ProductDatabase connection string from the config file
            var connString = ConfigurationManager.ConnectionStrings["ProductDatabase"].ConnectionString;

            _database = new Product.Sql.SqlProductDatabase(connString);
        }
        // GET: Nile
        public ActionResult Index()
        {
            var products = _database.GetAll();

            var model = products.Select(x => new ProductModel(x));
            return View("List", model);
        }


        //GET : Details
        public ActionResult Details ( int id )
        {
            var product = _database.Get(id);
            if (product == null)
                return HttpNotFound(); //404

            return View(new ProductModel(product));

        }

        //GET: Edit
        public ActionResult Edit ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound(); //404
            return View(new ProductModel(movie));
        }

        private readonly IProductDatabase _database;
    }
}