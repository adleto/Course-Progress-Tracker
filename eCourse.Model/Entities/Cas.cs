using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class Cas
    {
        public int Id { get; set; }
        public virtual KursInstanca KursInstanca { get; set; }
        [ForeignKey(nameof(KursInstanca))]
        public int KursInstancaId { get; set; }
        public DateTime DatumVrijemeOdrzavanja { get; set; }
        public string Lokacija { get; set; }
        public string Opis { get; set; }
        public bool Odrzan { get; set; }
    }
}
