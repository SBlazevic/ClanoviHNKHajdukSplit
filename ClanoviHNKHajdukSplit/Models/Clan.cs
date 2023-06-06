using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ClanoviHNKHajdukSplit.Models;

namespace ClanoviHNKHajdukSplit.Models
{
    public class Clan
    {
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [Display(Name = "Ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [Display(Name = "Slika")]
        public string SlikaUrl { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [Display(Name = "Uloga")]
        public int UlogaId { get; set;  }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        public Uloga Uloga { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [Display(Name = "Članarina")]
        public int ClanarinaId { get; set; }
        public Clanarina Clanarina { get; set; }
    }
}
