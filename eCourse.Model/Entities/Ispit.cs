using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class Ispit
    {
        public int Id { get; set; }
        public virtual KursInstanca KursInstanca { get; set; }
        [ForeignKey(nameof(KursInstanca))]
        public int KursInstancaId { get; set; }
        public DateTime DatumVrijemeIspita { get; set; }
        public string Lokacija { get; set; }
        public virtual List<IspitKlijentKursInstanca> KlijentiNaIspitu { get; set; }
    }
}
