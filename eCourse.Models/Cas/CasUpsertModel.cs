using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.Cas
{
    public class CasUpsertModel
    {
        [Required]
        public DateTime DatumVrijemeOdrzavanja { get; set; }
        [Required]
        public string Lokacija { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public bool Odrzan { get; set; }
        [Required]
        public int KursInstancaId { get; set; }
    }
}
