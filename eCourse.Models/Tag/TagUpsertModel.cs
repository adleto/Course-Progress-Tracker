using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.Tag
{
    public class TagUpsertModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }
    }
}
