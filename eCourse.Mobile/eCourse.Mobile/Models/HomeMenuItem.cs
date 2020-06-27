using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Mobile.Models
{
    public enum MenuItemType
    {
        Uplate,
        Profil,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
