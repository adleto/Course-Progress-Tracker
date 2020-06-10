using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class KursTag
    {
        public virtual Kurs Kurs { get; set; }

        [ForeignKey(nameof(Kurs))]
        public int KursId { get; set; }
        public virtual Tag Tag { get; set; }
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }
    }
}
