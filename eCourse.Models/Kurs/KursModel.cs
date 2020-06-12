using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.Kurs
{
    public class KursModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string Naziv { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string SkraceniNaziv { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Opis { get; set; }
    }
}
