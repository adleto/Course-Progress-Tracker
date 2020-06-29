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
        public bool? Polozen { get; set; }
        public List<CasModel> Casovi { get; set; }
        public decimal? Cijena { get; set; }
        public DateTime? VrijemeIspit { get; set; }
        public string LokacijaIspit { get; set; }
        public decimal? IspitPoeni { get; set; }
        public int? Kapacitet { get; set; }
        public bool? UplataIzvrsena { get; set; }
        public bool? PrisustvovoIspitu { get; set; }

        public bool NijePrijavljen { get; set; }
        public bool PrijavljenIAktivan { get; set; }
        public bool PrijavljenAliNeUplacen { get; set; }
        public bool Ocijenjen { get; set; }
        public bool Zavrsen { get; set; }
    }
}
