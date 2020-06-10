using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class ApplicationUserInsertModel : ApplicationUserUpdateModel
    {
        [Required(AllowEmptyStrings = false)]
        public override string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public override string PasswordConfirm { get; set; }
    }
}
