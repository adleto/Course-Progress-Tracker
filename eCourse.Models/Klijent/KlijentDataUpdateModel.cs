using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.Klijent
{
    public class KlijentDataUpdateModel
    {
        public int? OpcinaId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public byte[] Slika { get; set; }
        public string Password { get; set; }
    }
}
