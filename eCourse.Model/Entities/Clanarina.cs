using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class Clanarina
    {
        public int Id { get; set; }
        public virtual Klijent Klijent { get; set; }
        [ForeignKey(nameof(Klijent))]
        public int KlijentId { get; set; }
        public DateTime DatumIsteka { get; set; }
        public virtual Uplata Uplata { get; set; }
        [ForeignKey(nameof(Uplata))]
        public int UplataId { get; set; }
    }
}
