using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _2aProvaEsame.Models
{
    public class DatiRichiesta
    {
        [Key]
        public int DatiRichiestaId { get; set; }

        [Required]
        [ForeignKey(nameof(Richiedente))]
        public int RichiedenteId { get; set; }
        public virtual DatiAnagrafici Richiedente { get; set; }

        [Required]
        [ForeignKey(nameof(Assegnato))]
        public int AssegnatoeId { get; set; }
        public virtual DatiAnagrafici Assegnato { get; set; }

        [Required]
        public DateTime DataRichiesta { get; set; }
        public DateTime? DataChiusura { get; set; }
        [Required]
        public int StatoRichiesta { get; set; }
        [Required]
        public string TitoloRichiesta { get; set; }
        [Required]
        public string DescrizioneRichiesta { get; set; }
        public string DescrizioneRisposta { get; set; }
    }
}
