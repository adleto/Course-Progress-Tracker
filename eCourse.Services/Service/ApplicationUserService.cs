using AutoMapper;
using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.ApplicationUser;
using eCourse.Services.Helpers;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly CourseContext _context;
        private readonly IMapper _mapper;

        public ApplicationUserService(CourseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OsobljeModel> AddOsoblje(OsobljeInsertModel model)
        {
            try
            {
                if (model.Password != model.PasswordConfirm)
                {
                    throw new Exception("Lozinke nisu iste.");
                }
                if (!(IsUsernameUnique(model.Username)))
                {
                    throw new Exception("Username je već zauzet.");
                }
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    PasswordSalt = UserAuthHelpers.GenerateSalt(),
                    Slika = model.Slika,
                    Username = model.Username,
                    DatumRodjenja = model.DatumRodjenja,
                    Ime = model.Ime,
                    JMBG = model.JMBG,
                    OpcinaId = model.OpcinaId,
                    Prezime = model.Prezime,
                    Spol = model.Spol,
                    DatumRegistracije = DateTime.Now,
                    Active = model.Active
                };
                user.PasswordHash = UserAuthHelpers.GenerateHash(user.PasswordSalt, model.Password);
                _context.ApplicationUser.Add(user);
                foreach (var r in model.ApplicationUserRoles)
                {
                    _context.ApplicationUserRole.Add(new ApplicationUserRole
                    {
                        ApplicationUser = user,
                        RoleId = r.Id
                    });
                }
                var uposlenik = new Uposlenik
                {
                    DatumZaposlenja = model.DatumZaposlenja,
                    ApplicationUser = user
                };
                _context.Uposlenik.Add(uposlenik);
                await _context.SaveChangesAsync();
                var created = new OsobljeModel
                {
                    DatumRodjenja = user.DatumRodjenja,
                    DatumZaposlenja = uposlenik.DatumZaposlenja,
                    Active = user.Active,
                    Email = user.Email,
                    Id = user.Id,
                    Ime = user.Ime,
                    JMBG = user.JMBG,
                    OpcinaId = user.OpcinaId,
                    Prezime = user.Prezime,
                    Spol = user.Spol,
                    UposlenikId = uposlenik.Id,
                    Slika = user.Slika,
                    Username = user.Username,
                    Role = model.ApplicationUserRoles
                };
                created.OpcinaNaziv = _context.Opcina
                    .Find(created.OpcinaId)
                    .Naziv;
                return created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool IsUsernameUnique(string username)
        {
            var user = _context.ApplicationUser
                .Where(u => u.Username == username)
                .FirstOrDefault();
            if (user == null) return true;
            return false;
        }

        public async Task<ApplicationUserModel> Authenticate(string username, string password)
        {
            var user = await _context.ApplicationUser
                .Include(au => au.ApplicationUserRoles)
                    .ThenInclude(r => r.Role)
                .Include(o => o.Opcina)
                .FirstOrDefaultAsync(x => x.Username == username && x.Active == true);
            if (user != null)
            {
                if (user.PasswordHash == UserAuthHelpers.GenerateHash(user.PasswordSalt, password))
                {
                    var rolesModel = new List<RoleModel>();
                    foreach (var x in user.ApplicationUserRoles)
                    {
                        rolesModel.Add(new RoleModel
                        {
                            Naziv = x.Role.Naziv,
                            Id = x.RoleId
                        });
                    }
                    var model = new ApplicationUserModel
                    {
                        ApplicationUserRoles = rolesModel,
                        Email = user.Email,
                        Id = user.Id,
                        Username = user.Username
                    };
                    if (rolesModel.Where(r => r.Naziv == "Klijent").Any())
                    {
                        model.KlijentId = _context.Klijent.Where(k => k.ApplicationUserId == model.Id).First().Id;
                    }
                    else if (rolesModel.Where(r => r.Naziv == "AdministrativnoOsoblje" || r.Naziv == "Predavač").Any())
                    {
                        model.UposlenikId = _context.Uposlenik.Where(k => k.ApplicationUserId == model.Id).First().Id;
                    }
                    return model;
                }
            }
            return null;
        }

        public OsobljeModel GetOsoblje(int id)
        {
            try
            {
                var uposlenik = _context.Uposlenik
                    .Include(u => u.ApplicationUser)
                        .ThenInclude(au => au.ApplicationUserRoles)
                            .ThenInclude(aur => aur.Role)
                    .Include(u => u.ApplicationUser.Opcina)
                    .Where(u => u.ApplicationUserId == id)
                    .FirstOrDefault();

                return MapUposlenikToOsobljeModel(uposlenik); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OsobljeModel> UpdateOsoblje(int id, OsobljeUpdateModel model)
        {
            try
            {
                var uposlenik = _context.Uposlenik
                    .Include(u => u.ApplicationUser)
                        .ThenInclude(au => au.ApplicationUserRoles)
                            .ThenInclude(aur => aur.Role)
                    .Include(u => u.ApplicationUser)
                        .ThenInclude(au => au.Opcina)
                    .Where(u => u.ApplicationUserId == id)
                    .FirstOrDefault();

                uposlenik.ApplicationUser.Active = model.Active;
                uposlenik.ApplicationUser.DatumRodjenja = model.DatumRodjenja;
                uposlenik.DatumZaposlenja = model.DatumZaposlenja;
                uposlenik.ApplicationUser.Email = model.Email;
                uposlenik.ApplicationUser.Ime = model.Ime;
                uposlenik.ApplicationUser.JMBG = model.JMBG;
                if (uposlenik.ApplicationUser.OpcinaId != model.OpcinaId)
                {
                    uposlenik.ApplicationUser.OpcinaId = model.OpcinaId;
                    uposlenik.ApplicationUser.Opcina = _context.Opcina.Find(model.OpcinaId);
                }
                uposlenik.ApplicationUser.Prezime = model.Prezime;
                if (model.Slika != null && model.Slika.Length > 0) uposlenik.ApplicationUser.Slika = model.Slika;
                uposlenik.ApplicationUser.Spol = model.Spol;

                //new password if not empty
                if (!string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.PasswordConfirm))
                {
                    if (model.Password != model.PasswordConfirm)
                    {
                        throw new Exception("Passwords are not a match.");
                    }
                    uposlenik.ApplicationUser.PasswordHash = UserAuthHelpers.GenerateHash(uposlenik.ApplicationUser.PasswordSalt, model.Password);
                }

                //removing all roles
                var existingRoles = await _context.ApplicationUserRole
                    .Where(a => a.ApplicationUserId == uposlenik.ApplicationUser.Id)
                    .ToListAsync();
                foreach (var er in existingRoles)
                {
                    _context.ApplicationUserRole.Remove(er);
                }
                //adding updated roles
                foreach (var r in model.ApplicationUserRoles)
                {
                    uposlenik.ApplicationUser.ApplicationUserRoles.Add(new ApplicationUserRole
                    {
                        ApplicationUserId = uposlenik.ApplicationUser.Id,
                        RoleId = r.Id,
                        Role = _context.Role.Find(r.Id)
                    });
                }

                await _context.SaveChangesAsync();

                return MapUposlenikToOsobljeModel(uposlenik);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OsobljeModel>> GetOsoblje(UserSearchRequestModel model = null)
        {
            try
            {
                var query = _context.Uposlenik
                    .Include(u => u.ApplicationUser)
                        .ThenInclude(au => au.ApplicationUserRoles)
                            .ThenInclude(aur => aur.Role)
                    .Include(u => u.ApplicationUser.Opcina)
                    .AsQueryable();
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.Ime))
                    {
                        query = query
                            .Where(u => u.ApplicationUser.Ime.StartsWith(model.Ime));
                    }
                    if (!string.IsNullOrEmpty(model.Prezime))
                    {
                        query = query
                            .Where(u => u.ApplicationUser.Prezime.StartsWith(model.Prezime));
                    }
                }
                var result = await query.ToListAsync();
                var returnModel = new List<OsobljeModel>();
                foreach (var r in result)
                {
                    returnModel.Add(MapUposlenikToOsobljeModel(r));
                }

                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private OsobljeModel MapUposlenikToOsobljeModel(Uposlenik model)
        {
            try
            {
                var returnModel = new OsobljeModel
                {
                    Active = model.ApplicationUser.Active,
                    DatumRodjenja = model.ApplicationUser.DatumRodjenja,
                    DatumZaposlenja = model.DatumZaposlenja,
                    Email = model.ApplicationUser.Email,
                    Id = model.ApplicationUser.Id,
                    Ime = model.ApplicationUser.Ime,
                    JMBG = model.ApplicationUser.JMBG,
                    OpcinaId = model.ApplicationUser.OpcinaId,
                    OpcinaNaziv = model.ApplicationUser.Opcina.Naziv,
                    Prezime = model.ApplicationUser.Prezime,
                    Slika = model.ApplicationUser.Slika,
                    Spol = model.ApplicationUser.Spol,
                    UposlenikId = model.Id,
                    Username = model.ApplicationUser.Username
                };
                returnModel.Role = new List<RoleModel>();
                foreach (var r in model.ApplicationUser.ApplicationUserRoles)
                {
                    returnModel.Role.Add(new RoleModel
                    {
                        Id = r.RoleId,
                        Naziv = r.Role.Naziv
                    });
                }
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private KlijentModel MapKlijentToKlijentModel(Klijent model)
        {
            try
            {
                var returnModel = new KlijentModel
                {
                    DatumRodjenja = model.ApplicationUser.DatumRodjenja,
                    Email = model.ApplicationUser.Email,
                    Id = model.ApplicationUser.Id,
                    Ime = model.ApplicationUser.Ime,
                    JMBG = model.ApplicationUser.JMBG,
                    OpcinaId = model.ApplicationUser.OpcinaId,
                    OpcinaNaziv = model.ApplicationUser.Opcina.Naziv,
                    Prezime = model.ApplicationUser.Prezime,
                    Slika = model.ApplicationUser.Slika,
                    Spol = model.ApplicationUser.Spol,
                    KlijentId = model.Id,
                    Username = model.ApplicationUser.Username
                };
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<KlijentModel>> GetKlijenti(int uposlenikId, List<string> roles, KlijentSearchRequestModel model = null)
        {
            try
            {
                var query = _context.Klijent
                    .Include(u => u.ApplicationUser)
                        .ThenInclude(au => au.Opcina)
                    .Include(u => u.KurseviKlijenta)
                        .ThenInclude(k => k.KursInstanca)
                    .AsQueryable();
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.Ime))
                    {
                        query = query
                            .Where(u => u.ApplicationUser.Ime.StartsWith(model.Ime));
                    }
                    if (!string.IsNullOrEmpty(model.Prezime))
                    {
                        query = query
                            .Where(u => u.ApplicationUser.Prezime.StartsWith(model.Prezime));
                    }
                }
                var result = await query.ToListAsync();

                bool isAdmin = roles.Contains("AdministrativnoOsoblje");
                bool isPredavacOnCourse = false;
                if (model?.KursInstancaId != null)
                {
                    isPredavacOnCourse = IsPredavacOnCourse(uposlenikId, (int)model.KursInstancaId);
                }

                var returnModel = new List<KlijentModel>();
                foreach (var r in result)
                {
                    bool passed = false; //zbog uplate da ne ide ponovo trip na db ako sigurno ne treba
                    if (model?.KursInstancaId != null && model?.KursInstancaId != 0)
                    {
                        if ((isAdmin || isPredavacOnCourse) && IsKlijentOnCourse(r, (int)model.KursInstancaId))
                        {
                            passed = true;
                        }
                    }
                    else
                    {
                        if (isAdmin)
                        {
                            passed = true;
                        }
                        else if (IsKlijentOnAnyCourseFromUposlenik(r, uposlenikId))
                        {
                            passed = true;
                        }
                    }

                    if (passed)
                    {
                        var k = MapKlijentToKlijentModel(r);
                        k.UkupnoUplaceno = GetUkupnoUplaceno(k.KlijentId);
                        var clanarinaKlijenta = await _context.Clanarina
                            .Where(c => c.KlijentId == k.KlijentId)
                            .OrderByDescending(c => c.Id)
                            .ToListAsync();
                        if (clanarinaKlijenta.Count == 0 || clanarinaKlijenta[0].DatumIsteka < DateTime.Now)
                        {
                            k.ClanarinaAktivna = "Neaktivna";
                        }
                        else
                        {
                            k.DatumIstekaClanarine = clanarinaKlijenta[0].DatumIsteka;
                            if (clanarinaKlijenta[0].DatumIsteka > DateTime.Now)
                            {
                                k.ClanarinaAktivna = "Aktivna";
                            }
                        }
                        returnModel.Add(k);
                    }
                }

                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private decimal GetUkupnoUplaceno(int klijentId)
        {
            return _context.Uplata
                .Where(u => u.KlijentId == klijentId)
                .Sum(u => u.Iznos);
        }

        private bool IsPredavacOnCourse(int userId, int kursInstancaId)
        {
            var kursInstanca = _context.KursInstanca.Find(kursInstancaId);
            if (kursInstanca.UposlenikId == userId) return true;
            return false;
        }
        private bool IsKlijentOnCourse(Klijent klijent, int kursInstancaId)
        {
            foreach (var k in klijent.KurseviKlijenta)
            {
                if (k.KursInstancaId == kursInstancaId)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsKlijentOnAnyCourseFromUposlenik(Klijent klijent, int uposlenikId)
        {
            foreach (var k in klijent.KurseviKlijenta)
            {
                if (k.KursInstanca.UposlenikId == uposlenikId)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<KlijentSimpleModel>> GetKlijentiSimple()
        {
            try
            {
                var result = await _context.Klijent
                    .Include(r => r.ApplicationUser)
                    .ToListAsync();
                var resultModel = new List<KlijentSimpleModel>();
                result.ForEach(r => resultModel.Add(MapKlijentToKlijentSimpleModel(r)));
                return resultModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private KlijentSimpleModel MapKlijentToKlijentSimpleModel(Klijent k)
        {
            return new KlijentSimpleModel
            {
                ApplicationUserId = k.ApplicationUserId,
                DatumRodjenja = k.ApplicationUser.DatumRodjenja,
                ImeIPrezime = k.ApplicationUser.Ime + " " + k.ApplicationUser.Prezime,
                KlijentId = k.Id
            };
        }

        public async Task<KlijentModel> AddKlijent(ApplicationUserInsertModel model)
        {
            try
            {
                if (model.Password != model.PasswordConfirm)
                {
                    throw new Exception("Lozinke nisu iste.");
                }
                if (!(IsUsernameUnique(model.Username)))
                {
                    throw new Exception("Username je već zauzet.");
                }
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    PasswordSalt = UserAuthHelpers.GenerateSalt(),
                    Username = model.Username,
                    DatumRodjenja = model.DatumRodjenja,
                    Ime = model.Ime,
                    JMBG = model.JMBG,
                    OpcinaId = model.OpcinaId,
                    Prezime = model.Prezime,
                    Spol = model.Spol,
                    DatumRegistracije = DateTime.Now,
                    Active = true
                };
                if(model.Slika!=null && model.Slika.Length > 0)
                {
                    user.Slika = model.Slika;
                }
                user.PasswordHash = UserAuthHelpers.GenerateHash(user.PasswordSalt, model.Password);
                _context.ApplicationUser.Add(user);

                var roleKlijent = _context.Role.Where(r => r.Naziv == "Klijent").First();
                _context.ApplicationUserRole.Add(new ApplicationUserRole
                {
                    ApplicationUser = user,
                    Role = roleKlijent
                });
                var klijent = new Klijent {
                    ApplicationUser = user
                };
                _context.Klijent.Add(klijent);
                await _context.SaveChangesAsync();
                var created = new KlijentModel
                {
                    DatumRodjenja = user.DatumRodjenja,
                    Email = user.Email,
                    Id = user.Id,
                    Ime = user.Ime,
                    JMBG = user.JMBG,
                    OpcinaId = user.OpcinaId,
                    Prezime = user.Prezime,
                    Spol = user.Spol,
                    Slika = user.Slika,
                    Username = user.Username,
                    Role = new List<RoleModel> { new RoleModel { Id = roleKlijent.Id, Naziv = roleKlijent.Naziv} },
                    KlijentId = klijent.Id
                };
                created.OpcinaNaziv = _context.Opcina
                    .Find(created.OpcinaId)
                    .Naziv;
                return created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
