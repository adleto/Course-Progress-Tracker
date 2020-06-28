using eCourse.Models.Cas;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Klijent
{
    public class KursDataModel
    {
        public int KursInstancaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Predavac { get; set; }
        public int? Ocjena { get; set; }
        public int? KlijentKursInstancaId { get; set; }
        public int BrojCasova { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime? DatumKraja { get; set; }
        public DateTime DatumPrijaveDo { get; set; }
        public bool Polozen { get; set; }
        public List<CasModel> Casovi { get; set; }
        public decimal? Cijena { get; set; }
    }
}
