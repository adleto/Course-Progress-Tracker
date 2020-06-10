using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class Klijent
    {
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public int ApplicationUserId { get; set; }
        public virtual List<KlijentKursInstanca> KurseviKlijenta { get; set; }
        public virtual List<Uplata> UplateKlijenta { get; set; }
        public virtual List<Clanarina> ClanarineKlijenta { get; set; }
    }
}
