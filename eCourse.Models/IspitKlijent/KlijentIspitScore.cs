using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.IspitKlijent
{
    public class KlijentIspitScore
    {
        public int Id { get; set; }
        public bool Prisustvo { get; set; }
        public decimal? Bodovi { get; set; }
    }
}
