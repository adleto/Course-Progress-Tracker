using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class Uplata
    {
        public int Id { get; set; }
        public virtual TipUplate TipUplate { get; set; }
        [ForeignKey(nameof(TipUplate))]
        public int TipUplateId { get; set; }
        public DateTime DatumUplate { get; set; }
        public decimal Iznos { get; set; }
        public virtual Klijent Klijent { get; set; }
        [ForeignKey(nameof(Klijent))]
        public int KlijentId { get; set; }
        public KursInstanca KursInstanca { get; set; }
        [ForeignKey(nameof(KursInstanca))]
        public int? KursInstancaId { get; set; }
    }
}
