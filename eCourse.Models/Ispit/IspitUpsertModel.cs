using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Ispit
{
    public class IspitUpsertModel
    {
        public int KursInstancaId { get; set; }
        public DateTime DatumVrijemeIspita { get; set; }
        public string Lokacija { get; set; }
    }
}
