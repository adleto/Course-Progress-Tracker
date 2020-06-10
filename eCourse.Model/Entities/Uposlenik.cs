using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class Uposlenik
    {
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public int ApplicationUserId { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public virtual List<KursInstanca> KurseviUposlenika { get; set; }
    }
}
