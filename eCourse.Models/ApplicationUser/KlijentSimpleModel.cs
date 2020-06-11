using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class KlijentSimpleModel
    {
        public int KlijentId { get; set; }
        public int ApplicationUserId { get; set; }
        public string ImeIPrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string NazivSaDatumom { get {
                return ImeIPrezime + " (Rođen: " + DatumRodjenja.ToString("yyyy/MM/dd") + ")"; 
            } }
    }
}
