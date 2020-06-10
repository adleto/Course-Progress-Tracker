using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class OsobljeModel : ApplicationUserGetModel
    {
        public DateTime DatumZaposlenja { get; set; }
        public bool Active { get; set; }
        public int UposlenikId { get; set; }
    }
}
