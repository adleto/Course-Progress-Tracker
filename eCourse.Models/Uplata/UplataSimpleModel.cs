using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Uplata
{
    public class UplataSimpleModel
    {
        public int UplataId { get; set; }
        public decimal Iznos { get; set; }
        public int KlijentId { get; set; }
    }
}
