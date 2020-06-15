using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace eCourse.Models.KursInstanca
{
    public class MojaKursInstanca
    {
        public int KursInstancaId { get; set; }
        public int UposlenikId { get; set; }
        public string UposlenikIme { get; set; }
        public string UposlenikPrezime { get; set; }
        public string UposlenikImeIPrezime { get { return UposlenikIme + " " + UposlenikPrezime; } }
        public DateTime Pocetak { get; set; }
        public string KrajOpis { get; set; }
        public string KursNaziv { get; set; }
        public string KursSkraceniNaziv { get; set; }
        public int BrojKlijenata { get; set; }
        public string ZavrsenOpis { get; set; }
        public DateTime PrijaveDo { get; set; }
        public string KapacitetOpis { get; set; }
        public int? Kapacitet { get; set; }
        public DateTime? KrajDate { get; set; }
        public int BrojCasova { get; set; }
        public bool IspitOrganizovan { get; set; }
        public int? IspitId { get; set; }
    }
}
