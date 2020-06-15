using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class IspitKlijentKursInstanca
    {
        public int Id { get; set; }
        public virtual Ispit Ispit { get; set; }
        [ForeignKey(nameof(Ispit))]
        public int IspitId { get; set; }
        public virtual KlijentKursInstanca KlijentKursInstanca { get; set; }
        [ForeignKey(nameof(KlijentKursInstanca))]
        public int KlijentKursInstancaId { get; set; }
        public bool Prisustvovao { get; set; }
        public decimal? Bodovi { get; set; }
    }
}
