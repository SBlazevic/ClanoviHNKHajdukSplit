namespace ClanoviHNKHajdukSplit.Models
{
    public interface IRepozitorijUpita
    {
        public IEnumerable<Clan> PopisClanova();
        public void Create(Clan clan);
        public void Update(Clan clan);
        public void Delete(Clan clan);

        int SljedeciId();
        Clan DohvatiClanaSIdom(int id);

        public IEnumerable<Uloga> PopisUloga();
        public void Create(Uloga uloga);
        public void Update(Uloga uloga);
        public void Delete(Uloga uloga);

        Uloga DohvatiUloguSIdom(int id);

        public IEnumerable<Clanarina> PopisClanarina();
        public void Create(Clanarina clanarina);
        public void Update(Clanarina clanarina);
        public void Delete(Clanarina clanarina);

        Clanarina DohvatiClanarinuSIdom(int id);
    }
}
