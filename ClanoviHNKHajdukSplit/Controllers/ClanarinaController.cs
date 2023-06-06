using ClanoviHNKHajdukSplit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClanoviHNKHajdukSplit.Controllers
{
    public class ClanarinaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public ClanarinaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisClanarina());
        }

        [HttpGet]
        public IActionResult Create()
        {
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Clanarina clanarina = new Clanarina { Id = sljedeciId };
            return View(clanarina);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Vrsta, Cijena")] Clanarina clanarina)
        {
            ModelState.Remove("Clanovi");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(clanarina);
                return RedirectToAction("Index");
            }
            return View(clanarina);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Clanarina clanarina = _repozitorijUpita.DohvatiClanarinuSIdom(id);

            if (clanarina == null)
            {
                return NotFound();
            }
            return View(clanarina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id, Vrsta, Cijena")] Clanarina clanarina)
        {
            if (id != clanarina.Id) { return NotFound(); }

            ModelState.Remove("Clanovi");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(clanarina);
                return RedirectToAction("Index");
            }

            return View(clanarina);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1) { return NotFound(); }

            var clanarina = _repozitorijUpita.DohvatiClanarinuSIdom(Convert.ToInt16(id));
            if (clanarina == null) { return NotFound(); }
            return View(clanarina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var clanarina = _repozitorijUpita.DohvatiClanarinuSIdom(id);
            _repozitorijUpita.Delete(clanarina);
            return RedirectToAction("Index");
        }
    }
}
