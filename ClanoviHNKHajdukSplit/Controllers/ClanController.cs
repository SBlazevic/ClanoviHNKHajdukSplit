using ClanoviHNKHajdukSplit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace ClanoviHNKHajdukSplit.Controllers
{
    public class ClanController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public ClanController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisClanova());
        }

        public IActionResult Create()
        {
            ViewData["ClanarinaId"] = new SelectList(_repozitorijUpita.PopisClanarina(), "Id", "Vrsta", "Cijena");
            ViewData["UlogaId"] = new SelectList(_repozitorijUpita.PopisUloga(), "Id", "UlogaNaziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Clan clan = new Clan() { Id = sljedeciId };
            return View(clan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Ime, Prezime, SlikaUrl, UlogaId, ClanarinaId")] Clan clan)
        {
            ModelState.Remove("Clanarina");
            ModelState.Remove("Uloga");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(clan);
                return RedirectToAction("Index");
            }

            ViewData["ClanarinaId"] = new SelectList(_repozitorijUpita.PopisClanarina(), "Id", "Vrsta", "Cijena");
            ViewData["UlogaId"] = new SelectList(_repozitorijUpita.PopisUloga(), "Id", "UlogaNaziv");
            return View(clan);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Clan clan = _repozitorijUpita.DohvatiClanaSIdom(id);

            if (clan == null)
            {
                return NotFound();
            }
            ViewData["ClanarinaId"] = new SelectList(_repozitorijUpita.PopisClanarina(), "Id", "Vrsta", "Cijena");
            ViewData["UlogaId"] = new SelectList(_repozitorijUpita.PopisUloga(), "Id", "UlogaNaziv");
            return View(clan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id, Ime, Prezime, SlikaUrl, UlogaId, ClanarinaId")] Clan clan)
        {
            if (id != clan.Id) { return NotFound(); }
            ModelState.Remove("Clanarina");
            ModelState.Remove("Uloga");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(clan);
                return RedirectToAction("Index");
            }

            ViewData["ClanarinaId"] = new SelectList(_repozitorijUpita.PopisClanarina(), "Id", "Vrsta", "Cijena");
            ViewData["UlogaId"] = new SelectList(_repozitorijUpita.PopisUloga(), "Id", "UlogaNaziv");
            return View(clan);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1) { return NotFound(); }

            var clan = _repozitorijUpita.DohvatiClanaSIdom(Convert.ToInt16(id));
            if (clan == null) { return NotFound(); }
            return View(clan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var clan = _repozitorijUpita.DohvatiClanaSIdom(id);
            _repozitorijUpita.Delete(clan);
            return RedirectToAction("Index");
        }

        public IActionResult SearchIndex(string clanUloga, string searchString)
        {
            var uloga = new List<string>();
            var ulogaUpit = _repozitorijUpita.PopisUloga();

            ViewData["clanUloga"] = new SelectList(_repozitorijUpita.PopisUloga(), "UlogaNaziv", "UlogaNaziv", ulogaUpit);

            var clanovi = _repozitorijUpita.PopisClanova();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                clanovi = clanovi.Where(s => s.Ime.Contains(searchString, StringComparison.OrdinalIgnoreCase) || s.Prezime.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (string.IsNullOrWhiteSpace(clanUloga))
                return View(clanovi);
            else
            {
                return View(clanovi.Where(x => x.Uloga.UlogaNaziv == clanUloga));
            }
        }
    }
}
