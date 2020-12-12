using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharacterRoster.Web.Models;


namespace CharacterRoster.Web.Controllers
{
    public class CharacterController : Controller
    {
        // GET: Character
        private static List<CharacterRoster> _characters;
       
        public CharacterController ()
        {

            _characters =  _characters == null ? new List<CharacterRoster>() : _characters;

            _database = _database == null ? new MemoryCharacterDatabase(_characters) : _database;

        }
        //Show all Character
        // GET: Character
        public ActionResult Index ()
        {

            var Character = _database.GetAll();
           
            var model = Character.Select(( CharacterRoster x ) => new CharacterRosterModel(x));

            return View("List", model);
        }

        //GET : Details
        public ActionResult Details ( int id )
        {
            var character = _database.Get(id);
            if (character == null)
                return HttpNotFound(); //404

            return View(new Models.CharacterRosterModel(character));
        }

        //GET: Edit
        public ActionResult Edit ( int id )
        {
            var character = _database.Get(id);
            if (character == null)
                return HttpNotFound(); //404

            return View(new Models.CharacterRosterModel(character));
        }

        // POST; Edit
        [HttpPost]
        public ActionResult Edit ( Models.CharacterRosterModel model )
        {
            //Check for model validation
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(model.ToCharacterRoster());
                    

                    return RedirectToAction(nameof(Details), new { id = model.Id });
                } catch(Exception e)
                {

                    ModelState.AddModelError("", e.Message);

                };

            };
            return View(model);
        }

        //GET: Create
        public ActionResult Create () => View(new CharacterRosterModel());


        // POST; Create
        [HttpPost]
        public ActionResult Create ( CharacterRosterModel model )
        {
            //Check for model validation
            if (ModelState.IsValid)
            {
                try
                {
                    var character = _database.Add(model.ToCharacterRoster());
                   
                    return RedirectToAction(nameof(Details), new { id = character.Id });
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
            var character = _database.Get(id);
            if (character == null)
                return HttpNotFound(); //404
            return View(new CharacterRosterModel(character));
        }

        // POST; Delete
        [HttpPost]
        public ActionResult Delete ( CharacterRosterModel model )
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

        private static  ICharacterDatabase _database;
    }
}