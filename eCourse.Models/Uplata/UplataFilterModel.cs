using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace eCourse.Models.Uplata
{
    public class UplataFilterModel
    {
        public DateTime? Od { get; set; }
        public DateTime? Do { get; set; }
        public int? KlijentId { get; set; }
    }
}
