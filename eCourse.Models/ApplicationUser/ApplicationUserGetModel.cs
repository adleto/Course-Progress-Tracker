using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class ApplicationUserGetModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string OpcinaNaziv { get; set; }
        public int OpcinaId { get; set; }
        public string JMBG { get; set; }
        public string Spol { get; set; }
        public byte[] Slika { get; set; }
        public List<RoleModel> Role { get; set; }
    }
}
