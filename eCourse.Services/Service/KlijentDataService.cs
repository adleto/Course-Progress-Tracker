using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Klijent;
using eCourse.Services.Helpers;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class KlijentDataService : IKlijentData
    {
        private readonly CourseContext _context;

        public KlijentDataService(CourseContext context)
        {
            _context = context;
        }

        public async Task<KlijentDataDisplayModel> GetKlijentData(int klijentId)
        {
            try
            {
                var klijent = _context.Klijent
                    .Include(k => k.ApplicationUser)
                        .ThenInclude(a => a.Opcina)
                    .Include(k => k.ClanarineKlijenta)
                    .Where(k => k.Id == klijentId)
                    .FirstOrDefault();
                return MapKlijentToDataDisplayModel(klijent);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<KlijentDataDisplayModel> UpdateKlijentData(int klijentId, KlijentDataUpdateModel model)
        {
            try
            {
                var klijent = _context.Klijent
                    .Include(k => k.ApplicationUser)
                        .ThenInclude(a => a.Opcina)
                    .Include(k => k.ClanarineKlijenta)
                    .Where(k => k.Id == klijentId)
                    .FirstOrDefault();
                if (model.Email != null)
                {
                    klijent.ApplicationUser.Email = model.Email;
                }
                if(model.Slika!=null && model.Slika.Length > 0)
                {
                    klijent.ApplicationUser.Slika = model.Slika;
                }
                if (model.Password != null)
                {
                    klijent.ApplicationUser.PasswordHash = UserAuthHelpers.GenerateHash(klijent.ApplicationUser.PasswordSalt, model.Password);
                }
                if(model.OpcinaId != null && model.OpcinaId != klijent.ApplicationUser.OpcinaId)
                {
                    klijent.ApplicationUser.OpcinaId = (int)model.OpcinaId;
                }
                await _context.SaveChangesAsync();
                return MapKlijentToDataDisplayModel(klijent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private KlijentDataDisplayModel MapKlijentToDataDisplayModel(Klijent klijent)
        {
            var returnModel = new KlijentDataDisplayModel
            {
                Email = klijent.ApplicationUser.Email,
                OpcinaId = klijent.ApplicationUser.OpcinaId,
                OpcinaNaziv = klijent.ApplicationUser.Opcina.Naziv,
                Slika = null
            };
            var clanarinaOrderedList = klijent.ClanarineKlijenta
                .OrderByDescending(c => c.DatumIsteka)
                .ToList();
            if (clanarinaOrderedList[0].DatumIsteka.Date > DateTime.Now.Date)
            {
                returnModel.ClanarinaAktivna = true;
                returnModel.ClanarinaAktivnaDo = clanarinaOrderedList[0].DatumIsteka.Date.ToString("dd/MM/yyyy");
            }
            else
            {
                returnModel.ClanarinaAktivna = false;
            }
            if (klijent.ApplicationUser.Slika != null && klijent.ApplicationUser.Slika.Length > 0)
            {
                returnModel.Slika = klijent.ApplicationUser.Slika;
            }
            return returnModel;
        }
    }
}
