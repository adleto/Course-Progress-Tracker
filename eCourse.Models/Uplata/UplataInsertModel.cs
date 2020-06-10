using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.Uplata
{
    public class UplataInsertModel
    {
        [Required]
        public decimal Iznos { get; set; }
        [Required]
        public int KlijentId { get; set; }
        public int? KursInstancaKlijentId { get; set; }
        public int TipUplate { get; set; }
    }
}
