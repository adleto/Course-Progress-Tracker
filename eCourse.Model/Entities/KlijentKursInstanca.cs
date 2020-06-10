using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class KlijentKursInstanca
    {
        public int Id { get; set; }
        public virtual Klijent Klijent { get; set; }
        [ForeignKey(nameof(Klijent))]
        public int KlijentId { get; set; }
        public virtual KursInstanca KursInstanca { get; set; }
        [ForeignKey(nameof(KursInstanca))]
        public int KursInstancaId { get; set; }
        public bool Active { get; set; }
        public bool? UplataIzvrsena { get; set; }
        public bool? Polozen { get; set; }
        public int? Rejting { get; set; }
    }
}
