using ABC.Core.Models;
using System;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Services
{
    public interface IBuyerInfoService
    {
        Task<BuyerInfo> GetBuyerInfoById(Guid id);
        Task<Guid> SaveBuyerInfo(BuyerInfo model);
    }
}
