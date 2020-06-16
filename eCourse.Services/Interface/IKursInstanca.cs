using eCourse.Models.KursInstanca;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IKursInstanca
    {
        KursInstancaSimpleModel GetInstancaSimple(int id);
        Task<List<KursInstancaModel>> Get(List<string> roles, int uposlenikId);
        Task<List<MojaKursInstanca>> GetMojiKursevi(int uposlenikId, MojaKursInstancaFilter model);
        Task<KursInstancaSimpleModel> DodajInstancu(int uposlenikId, KursInstancaInsertModel model);
        MojaKursInstancaProsireniModel GetInstanca(int id);
        Task<KursInstancaSimpleModel> UpdateInstanca(int uposlenikId, int id, KursInstancaUpdateModel model);
        Task<KursInstancaSimpleModel> ZavrsiInstancu(int uposlenikId, int id, bool postaviZaKlijenteKaoPolozili = true);
        Task<List<MojaKursInstancaForReport>> GetReport(KursInstancaFilter model);
    }
}
