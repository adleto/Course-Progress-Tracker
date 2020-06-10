using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.KursInstanca
{
    public class KursInstancaModel
    {
        public int Id { get; set; }
        public DateTime PocetakDatum { get; set; }
        public string KursNaziv { get; set; }
        public string KursSkraceniNaziv { get; set; }
        public string InstancaGivenName { get {
                if (KursNaziv == "") return "";
                return KursNaziv + " " + PocetakDatum.ToString("yyyy/MM/dd");
            } }
    }
}
