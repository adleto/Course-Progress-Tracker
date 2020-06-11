using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class KlijentModel : ApplicationUserGetModel
    {
        public int KlijentId { get; set; }
        public decimal UkupnoUplaceno { get; set; }
        public DateTime? DatumIstekaClanarine { get; set; }
        public string ClanarinaAktivna { get; set; }
    }
}
