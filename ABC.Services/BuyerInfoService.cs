using ABC.Core.Interfaces.Services;
using ABC.Core.Models;
using System;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class BuyerInfoService : IBuyerInfoService
    {
        public Task<BuyerInfo> GetBuyerInfoById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> SaveBuyerInfo(BuyerInfo model)
        {
            throw new NotImplementedException();
        }
    }
}
