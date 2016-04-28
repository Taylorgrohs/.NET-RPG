using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RPG.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RPG.Controllers
{
    public class CharacterController : Controller
    {
        private RPGContext db = new RPGContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Characters.ToList());
        }
        // GET: Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        public IActionResult Create(Character character)
        {
            if(character.Name == "Goku")
            {
                character.Level = 9001;
            }
            db.Characters.Add(character);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Edit
        public IActionResult Edit(int id)
        {
            Character thisCharacter = db.Characters.FirstOrDefault(characters => characters.CharacterId == id);
            return View(thisCharacter);
        }
        // POST: Edit
        [HttpPost]
        public IActionResult Edit(Character character)
        {
            db.Entry(character).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Delete
        public IActionResult Delete(int id)
        {
            Character thisCharacter = db.Characters.FirstOrDefault(characters => characters.CharacterId == id);
            return View(thisCharacter);
        }
        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Character thisCharacter = db.Characters.FirstOrDefault(characters => characters.CharacterId == id);
            db.Characters.Remove(thisCharacter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
