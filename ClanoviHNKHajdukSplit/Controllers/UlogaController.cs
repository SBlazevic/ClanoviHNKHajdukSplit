using ClanoviHNKHajdukSplit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClanoviHNKHajdukSplit.Controllers
{
    public class UlogaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public UlogaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisUloga());
        }

        [HttpGet]
        public IActionResult Create()
        {
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Uloga uloga = new Uloga { Id = sljedeciId };
            return View(uloga);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, UlogaNaziv")] Uloga uloga)
        {
            ModelState.Remove("Clanovi");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(uloga);
                return RedirectToAction("Index");
            }
            return View(uloga);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Uloga uloga = _repozitorijUpita.DohvatiUloguSIdom(id);

            if (uloga == null)
            {
                return NotFound();
            }
            return View(uloga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id, UlogaNaziv")] Uloga uloga)
        {
            if (id != uloga.Id) { return NotFound(); }

            ModelState.Remove("Clanovi");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(uloga);
                return RedirectToAction("Index");
            }

            return View(uloga);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1) { return NotFound(); }

            var uloga = _repozitorijUpita.DohvatiUloguSIdom(Convert.ToInt16(id));
            if (uloga == null) { return NotFound(); }
            return View(uloga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var uloga = _repozitorijUpita.DohvatiUloguSIdom(id);
            _repozitorijUpita.Delete(uloga);
            return RedirectToAction("Index");
        }
    }
}
