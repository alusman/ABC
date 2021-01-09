using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Services
{
    public interface IBuyerInfoService
    {
        Task<IEnumerable<BuyerInfo>> GetAllBuyerInfo();
        Task<BuyerInfo> GetBuyerInfoById(Guid id);
        Task<Guid> SaveBuyerInfo(BuyerInfo model);
        Task<int> UpdateBuyerInfo(BuyerInfo model);
        Task<bool> DeleteBuyerInfo(Guid id);
    }
}
