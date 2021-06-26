using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public interface IPromocodeService
    {
        Task<Promocode> CreatePromocode(Promocode promocode);
        Task DeletePromocode(int id);
        Task<List<Promocode>> GetPromocodes();
        Task<Promocode> IncreaseUsedTimes(int id);
        Task<Promocode> UpdatePromocode(Promocode promocode);
        Task<Promocode> GetPromocodeById(int id);
        Task<Promocode> GetPromocodeByCode(string code);
        bool IsAvailable(Promocode promocode);
        
    }
}