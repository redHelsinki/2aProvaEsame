using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2aProvaEsame.Models
{
    public class DatiAnagrafici
    {
        [Key]
        public int DatiAnagraficiId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Recapito Telefonico")]
        public string RecapitoTelefonico { get; set; }
        [Required]
        [Display(Name = "Indirizzo Completo")]
        public string IndirizzoCompleto { get; set; }
        [Required]
        [Display(Name = "Flag Cliente")]
        public bool FlagCliente { get; set; }
        [Required]
        [Display(Name = "Flag Interno")]
        public bool FlagInterno { get; set; }
        [Required]
        [Display(Name = "Flag Fornitore")]
        public bool FlagFornitore { get; set; }
        [Required]
        [Display(Name = "Codice Anagrafica")]
        public string CodiceAnagrafica { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual IEnumerable<DatiRichiesta> RichiesteCreate { get; set; }
        public virtual IEnumerable<DatiRichiesta> RichiesteAssegnate { get; set; }
    }
}
