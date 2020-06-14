using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace eCourse.Models.KursInstanca
{
    public class KursInstancaInsertModel
    {

        [Required]
        public int KursId { get; set; }

        [Required]
        public DateTime DatumPocetka { get; set; }

        [Required]
        public DateTime DatumPrijaveDo { get; set; }
        public int? Kapacitet { get; set; }
        public decimal? Cijena { get; set; }
        [Required]
        public int BrojCasova { get; set; }
    }
}
