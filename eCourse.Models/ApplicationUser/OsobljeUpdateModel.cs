using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class OsobljeUpdateModel : ApplicationUserUpdateModel
    {
        [Required(AllowEmptyStrings = false)]
        public DateTime DatumZaposlenja { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
