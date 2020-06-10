using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Uplata
{
    public class UplataModel
    {
        public int Id { get; set; }
        public decimal Iznos { get; set; }
        public string TipUplate { get; set; }
        public DateTime DatumUplate { get; set; }
        public string NamjenaZaKursInstancu { get; set; }
        public DateTime? ProduzenaClanarinaDo { get; set; }
        public string ImeIPrezimeKlijenta { get; set; }
    }
}
