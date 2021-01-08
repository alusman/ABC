using ABC.Core.Interfaces.Repositories;
using ABC.Core.Interfaces.Services;
using ABC.Core.Models;
using System;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class BuyerInfoService : IBuyerInfoService
    {
        private readonly IBuyerInfoRepository _buyerInfoRepository;

        public BuyerInfoService(IBuyerInfoRepository buyerInfoRepository)
        {
            if (buyerInfoRepository == null) throw new ArgumentNullException();
            _buyerInfoRepository = buyerInfoRepository;
        }

        public async Task<BuyerInfo> GetBuyerInfoById(Guid id)
        {
            return await _buyerInfoRepository.GetById(id).ConfigureAwait(false);
        }

        public async Task<Guid> SaveBuyerInfo(BuyerInfo model)
        {
            return await _buyerInfoRepository.Insert(model).ConfigureAwait(false);
        }
    }
}
