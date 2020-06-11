using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.TipUplate
{
    public class TipUplateModel
    {
        public int TipUplateId { get; set; }
        public string Naziv { get; set; }
        public decimal? Cijena { get; set; }
        public string PuniNaziv
        {
            get
            {
                var n = Naziv;
                if (Cijena != null)
                {
                    var c = (decimal)Cijena;
                    n += " (Mjesečni iznos; " + c.ToString("F") + ")";
                }
                return n;
            }
        }
    }
}
