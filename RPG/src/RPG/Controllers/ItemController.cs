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
    public class ItemController : Controller
    {
        private RPGContext db = new RPGContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        // GET: /Details /
        public IActionResult Details(int id)
        {
            
                var thisCharacter = (db.Items.Where(items => items.CharacterId == id).Include(items => items.Character).ToList());
            
            if (thisCharacter.Count() > 0)
            {
                return View(thisCharacter);
            } else
            {
               return RedirectToAction("Create", new { id = id });
            }

        }

        // GET: / Create /
        public IActionResult Create(int id)
        {
            ViewBag.CharacterId = id;
            return View();
        }

        // Post: / Create /
        [HttpPost]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index", "Character");
        }

    }
}
