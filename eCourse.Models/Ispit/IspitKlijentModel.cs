using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Ispit
{
    public class IspitKlijentModel
    {
        public int Id { get; set; }
        public int IspitId { get; set; }
        public string ImeIPrezime { get; set; }
        public int KlijentKursInstancaId { get; set; }
        public bool Prisustvovao { get; set; }
        public decimal? Bodovi { get; set; }
    }
}
