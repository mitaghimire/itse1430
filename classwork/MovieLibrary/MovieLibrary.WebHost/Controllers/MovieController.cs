using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MovieLibrary.WebHost.Models;

namespace MovieLibrary.WebHost.Controllers
{
    public class MovieController : Controller
    {
        public MovieController ()
        {
            //Gets the MovieDatabase connection string from the config file
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"].ConnectionString;

            _database = new MovieLibrary.Sql.SqlMovieDatabase(connString);
        }
        //Show all movie
        // GET: Movie
        public ActionResult Index()
        {

            var movies = _database.GetAll();

            // IEnumerable<MovieModel> model =
            var model = movies.Select(x => new MovieModel(x))
                              .OrderBy(x => x.Name);

            return View("List", model);   
        }

        //GET : Details
        public ActionResult Details (int id)
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound(); //404

            return View(new MovieModel(movie));
        }

        //GET: Edit
        public ActionResult Edit (int id)
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound(); //404
            return View(new MovieModel(movie));
        }

        // POST; Edit
        [HttpPost]
        public ActionResult Edit (MovieModel model)
        {
            //Check for model validation
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(model.Id, model.ToMovie());

                    return RedirectToAction(nameof(Details), new { id = model.Id });
                } catch(Exception e)
                {

                    ModelState.AddModelError("", e.Message);

                };
               

            };
            return View(model);
        }

        //GET: Create
        public ActionResult Create ( ) =>  View (new MovieModel ());
        

        // POST; Create
        [HttpPost]
        public ActionResult Create ( MovieModel model )
        {
            //Check for model validation
            if (ModelState.IsValid)
            {
                try
                {
                 var movie = _database.Add(model.ToMovie());

                    return RedirectToAction(nameof(Details), new { id = model.Id });
                } catch (Exception e)
                {

                    ModelState.AddModelError("", e.Message);

                };


            };
            return View(model);
        }

        //GET: Delete
        public ActionResult Delete ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound(); //404
            return View(new MovieModel(movie));
        }

        // POST; Delete
        [HttpPost]
        public ActionResult Delete ( MovieModel model )
        {
          
            
                try
                {
                    _database.Delete(model.Id);

                    return RedirectToAction(nameof(Index));
                } catch (Exception e)
                {

                    ModelState.AddModelError("", e.Message);

                };


            
            return View(model);
        }

        private readonly IMovieDatabase _database;
    }
}