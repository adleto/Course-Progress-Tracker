using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Database.Entities
{
    public class TipUplate
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public decimal? Cijena { get; set; }
    }
}
