using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ClanoviHNKHajdukSplit.Models
{
    public class Uloga
    {
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora ispuniti!")]
        [Display(Name = "Naziv")]
        public string UlogaNaziv { get; set; }
        public List<Clan> Clanovi { get; set; }
    }
}
