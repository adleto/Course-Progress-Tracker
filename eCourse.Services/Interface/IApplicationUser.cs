using eCourse.Models.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IApplicationUser
    {
        Task<ApplicationUserModel> Authenticate(string username, string password);
        Task<OsobljeModel> AddOsoblje(OsobljeInsertModel model);
        OsobljeModel GetOsoblje(int id);
        Task<List<OsobljeModel>> GetOsoblje(UserSearchRequestModel model = null);
        Task<OsobljeModel> UpdateOsoblje(int id, OsobljeUpdateModel model);
        Task<List<KlijentModel>> GetKlijenti(int uposlenikId, List<string> roles, KlijentSearchRequestModel model = null);
        Task<List<KlijentSimpleModel>> GetKlijentiSimple();
        Task<KlijentModel> AddKlijent(ApplicationUserInsertModel model);
    }
}
