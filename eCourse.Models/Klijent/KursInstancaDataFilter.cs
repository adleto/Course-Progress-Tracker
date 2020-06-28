using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Klijent
{
    public class KursInstancaDataFilter
    {
        public bool GetSve { get; set; }
        public bool GetMojiAktivni { get; set; }
        public bool GetMojiZavrseni { get; set; }
        public bool GetMojiUspjesnoZavrseni { get; set; }
        public int? TagId { get; set; }
        public string Pretraga { get; set; }
    }
}
