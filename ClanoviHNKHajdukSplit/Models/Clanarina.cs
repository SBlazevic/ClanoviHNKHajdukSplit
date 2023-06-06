using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ClanoviHNKHajdukSplit.Models
{
    public class Clanarina
    {
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        public string Vrsta { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        public decimal Cijena { get; set; }
        public List<Clan> Clanovi { get; set; }
    }
}
