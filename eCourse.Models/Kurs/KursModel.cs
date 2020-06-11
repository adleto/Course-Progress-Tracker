using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Kurs
{
    public class KursModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string SkraceniNaziv { get; set; }
        public string Opis { get; set; }
    }
}
