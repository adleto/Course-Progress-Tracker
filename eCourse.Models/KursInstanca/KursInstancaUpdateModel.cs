using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.KursInstanca
{
    public class KursInstancaUpdateModel
    {
        [Required]
        public DateTime PocetakDatum { get; set; }
        [Required]
        public DateTime PrijaveDoDatum { get; set; }
        public int? Kapacitet { get; set; }
    }
}
