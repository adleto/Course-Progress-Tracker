using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class KursInstanca
    {
        public int Id { get; set; }
        public virtual Kurs Kurs { get; set; }
        [ForeignKey(nameof(Kurs))]
        public int KursId { get; set; }
        public DateTime PocetakDatum { get; set; }
        public DateTime PrijaveDoDatum { get; set; }
        public DateTime? KrajDatum { get; set; }
        public int? Kapacitet { get; set; }
        public decimal? Cijena { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }
        [ForeignKey(nameof(Uposlenik))]
        public int UposlenikId { get; set; }
        public int BrojCasova { get; set; }
    }
}
