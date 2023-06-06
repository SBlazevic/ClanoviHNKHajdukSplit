using System.Runtime.InteropServices;
using ClanoviHNKHajdukSplit.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace ClanoviHNKHajdukSplit.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Clan> PopisClanova()
        {
            return _appDbContext.Clanovi.Include(u => u.Uloga).Include(c => c.Clanarina);
        }
        public void Create(Clan clan)
        {
            _appDbContext.Add(clan);
            _appDbContext.SaveChanges();
        }
        public void Update(Clan clan)
        {
            _appDbContext.Clanovi.Update(clan);
            _appDbContext.SaveChanges();
        }
        public void Delete(Clan clan)
        {
            _appDbContext.Clanovi.Remove(clan);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Uloga> PopisUloga()
        {
            return _appDbContext.Uloga;
        }
        public void Create(Uloga uloga)
        {
            _appDbContext.Add(uloga);
            _appDbContext.SaveChanges();
        }
        public void Update(Uloga uloga)
        {
            _appDbContext.Uloga.Update(uloga);
            _appDbContext.SaveChanges();
        }
        public void Delete(Uloga uloga)
        {
            _appDbContext.Uloga.Remove(uloga);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Clanarina> PopisClanarina()
        {
            return _appDbContext.Clanarina;
        }
        public void Create(Clanarina clanarina)
        {
            _appDbContext.Add(clanarina);
            _appDbContext.SaveChanges();
        }
        public void Update(Clanarina clanarina)
        {
            _appDbContext.Clanarina.Update(clanarina);
            _appDbContext.SaveChanges();
        }
        public void Delete(Clanarina clanarina)
        {
            _appDbContext.Clanarina.Remove(clanarina);
            _appDbContext.SaveChanges();
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Clanovi.Include(u => u.Uloga).Include(c => c.Clanarina).Max(x => x.Id);
            int sljedeciId = zadnjiId + 1;

            return sljedeciId;
        }

        public Clan DohvatiClanaSIdom(int id)
        {
            return _appDbContext.Clanovi.Include(u => u.Uloga).Include(c => c.Clanarina).FirstOrDefault(f => f.Id == id);
        }

        public Uloga DohvatiUloguSIdom(int id)
        {
            return _appDbContext.Uloga.Find(id);
        }

        public Clanarina DohvatiClanarinuSIdom(int id)
        {
            return _appDbContext.Clanarina.Find(id);
        }
    }
}
