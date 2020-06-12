using eCourse.Models.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Kurs
{
    public class KursProsireniModel : KursModel
    {
        public List<TagModel> Tagovi { get; set; }
    }
}
