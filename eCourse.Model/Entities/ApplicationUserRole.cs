using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class ApplicationUserRole
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public int ApplicationUserId { get; set; }
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
    }
}
