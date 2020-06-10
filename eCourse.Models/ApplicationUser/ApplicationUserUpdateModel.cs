using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCourse.Models.ApplicationUser
{
    public class ApplicationUserUpdateModel
    {
        [MinLength(4, ErrorMessage = "Username mora imati najmanje 4 karaktera.")]
        public string Username { get; set; }
        public List<RoleModel> ApplicationUserRoles { get; set; }
        [EmailAddress(ErrorMessage = "Email nije ispravan")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public DateTime DatumRodjenja { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int OpcinaId { get; set; }
        [MinLength(13, ErrorMessage = "Neispravan JMBG.")]
        [MaxLength(13, ErrorMessage = "Neispravan JMBG.")]
        public string JMBG { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Spol { get; set; }
        public virtual string Password { get; set; }
        public virtual string PasswordConfirm { get; set; }
        public byte[] Slika { get; set; }
    }
}
