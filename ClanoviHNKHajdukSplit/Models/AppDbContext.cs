using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ClanoviHNKHajdukSplit.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Clan> Clanovi { get; set; }
        public DbSet<Clanarina> Clanarina { get; set; }
        public DbSet<Uloga> Uloga { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Clanarina>().Property(c => c.Cijena).HasPrecision(5, 2);

            builder.Entity<Clan>().HasData(
                new Clan() { Id = 1, Ime = "Lukša", Prezime = "Jakobušić", SlikaUrl = "https://hajduk.hr/sadrzaj/organizacija/2021-11-05-luksa-jakobusic.jpg", ClanarinaId = 2, UlogaId = 1 },
                new Clan() { Id = 2, Ime = "Marko", Prezime = "Livaja", SlikaUrl = "https://hajduk.hr/sadrzaj/igraci/profil/2022-08-10-15-10-4880-.jpg", ClanarinaId = 2, UlogaId = 2 },
                new Clan() { Id = 3, Ime = "Stipe", Prezime = "Blažević", SlikaUrl = "https://img.uxwing.com/wp-content/themes/uxwing/download/peoples-avatars-thoughts/male-icon.svg", ClanarinaId = 1, UlogaId = 3 },
                new Clan() { Id = 4, Ime = "Filip", Prezime = "Krovinović", SlikaUrl = "https://hajduk.hr/sadrzaj/igraci/profil/2022-08-10-15-12-4030-.jpg", ClanarinaId = 2, UlogaId = 4 },
                new Clan() { Id = 5, Ime = "Ivan", Prezime = "Lučić", SlikaUrl = "https://hajduk.hr/sadrzaj/igraci/profil/2022-11-30-12-53-118-.jpg", ClanarinaId = 2, UlogaId = 6 },
                new Clan() { Id = 6, Ime = "Emir", Prezime = "Sahiti", SlikaUrl = "https://hajduk.hr/sadrzaj/igraci/profil/2022-08-10-15-13-6106-.jpg", ClanarinaId = 2, UlogaId = 5 },
                new Clan() { Id = 7, Ime = "Dario", Prezime = "Melnjak", SlikaUrl = "https://hajduk.hr/sadrzaj/igraci/profil/2022-08-10-15-11-119-.jpg", ClanarinaId = 2, UlogaId = 7 },
                new Clan() { Id = 8, Ime = "Luka", Prezime = "Hat", SlikaUrl = "https://img.uxwing.com/wp-content/themes/uxwing/download/peoples-avatars-thoughts/male-icon.svg", ClanarinaId = 1, UlogaId = 3 },
                new Clan() { Id = 9, Ime = "Fabijan", Prezime = "Dragojević", SlikaUrl = "https://img.uxwing.com/wp-content/themes/uxwing/download/peoples-avatars-thoughts/male-icon.svg", ClanarinaId = 1, UlogaId = 3 }
            );

            builder.Entity<Clanarina>().HasData(
                new Clanarina { Id = 1, Vrsta = "Standardna", Cijena = 150.00m },
                new Clanarina { Id = 2, Vrsta = "Povlaštena", Cijena = 100.00m }
                );

            builder.Entity<Uloga>().HasData(
                new Uloga() { Id = 1, UlogaNaziv = "Predsjednik udruge članova" },
                new Uloga() { Id = 2, UlogaNaziv = "Kapetan nogometne ekipe" },
                new Uloga() { Id = 3, UlogaNaziv = "Navijač" },
                new Uloga() { Id = 4, UlogaNaziv = "Vezni igrač nogometne ekipe" },
                new Uloga() { Id = 5, UlogaNaziv = "Napadač nogometne ekipe" },
                new Uloga() { Id = 6, UlogaNaziv = "Golman nogometne ekipe" },
                new Uloga() { Id = 7, UlogaNaziv = "Obrambeni igrač nogometne ekipe" }
                );
        }
    }
}
