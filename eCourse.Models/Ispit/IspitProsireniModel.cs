using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Ispit
{
    public class IspitProsireniModel : IspitModel
    {
        public List<IspitKlijentModel> IspitKlijentLista { get; set; }
        public string NazivKursa { get; set; }
    }
}
