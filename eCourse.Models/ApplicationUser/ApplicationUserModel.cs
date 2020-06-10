using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class ApplicationUserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<RoleModel> ApplicationUserRoles { get; set; }
        public string Email { get; set; }
    }
}
