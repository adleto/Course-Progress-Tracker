using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Cas
{
    public class CasModel
    {
        public int Id { get; set; }
        public DateTime DatumVrijemeOdrzavanja { get; set; }
        public string Lokacija { get; set; }
        public string Opis { get; set; }
        public bool Odrzan { get; set; }
    }
}
