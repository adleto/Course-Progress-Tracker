using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Klijent
{
    public class KlijentDataDisplayModel : KlijentDataUpdateModel
    {
        public string OpcinaNaziv { get; set; }
        public bool ClanarinaAktivna { get; set; }
        public string ClanarinaAktivnaDo { get; set; }
    }
}
