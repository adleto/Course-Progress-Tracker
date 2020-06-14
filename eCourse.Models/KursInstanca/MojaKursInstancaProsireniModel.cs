using eCourse.Models.Cas;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.KursInstanca
{
    public class MojaKursInstancaProsireniModel : MojaKursInstanca
    {
        public List<CasModel> Casovi { get; set; }
    }
}
