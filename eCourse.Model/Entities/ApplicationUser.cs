using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCourse.Database.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public byte[] Slika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public virtual Opcina Opcina { get; set; }
        [ForeignKey(nameof(Opcina))]
        public int OpcinaId { get; set; }
        public string JMBG { get; set; }
        public string Spol { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public bool Active { get; set; }
        public virtual List<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
