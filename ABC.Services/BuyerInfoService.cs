using ABC.Core.Interfaces.Repositories;
using ABC.Core.Interfaces.Services;
using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class BuyerInfoService : IBuyerInfoService
    {
        private readonly IBuyerInfoRepository _buyerInfoRepository;

        public BuyerInfoService(IBuyerInfoRepository buyerInfoRepository)
        {
            _buyerInfoRepository = buyerInfoRepository ?? throw new ArgumentNullException($"{nameof(buyerInfoRepository)} is required");
        }

        public async Task<IEnumerable<BuyerInfo>> GetAllBuyerInfo() => await _buyerInfoRepository.GetAll().ConfigureAwait(false);

        public async Task<BuyerInfo> GetBuyerInfoById(Guid id) => await _buyerInfoRepository.GetById(id).ConfigureAwait(false);

        public async Task<Guid> SaveBuyerInfo(BuyerInfo model) => await _buyerInfoRepository.Insert(model).ConfigureAwait(false);

        public async Task<int> UpdateBuyerInfo(BuyerInfo model) => await _buyerInfoRepository.Update(model).ConfigureAwait(false);

        public async Task<bool> DeleteBuyerInfo(Guid id) => await _buyerInfoRepository.Delete(id).ConfigureAwait(false);
    }
}
