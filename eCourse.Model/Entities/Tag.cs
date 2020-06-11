﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Database.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public virtual List<KursTag> KurseviSaTagom { get; set; }
    }
}
