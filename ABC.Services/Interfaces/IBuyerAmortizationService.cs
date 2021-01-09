using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Services.Interfaces
{
    public interface IBuyerAmortizationService
    {
        Task<IEnumerable<BuyerInfo>> GetAllBuyerInfo();
        Task<BuyerInfo> GetBuyerInfoById(Guid id);
        Task<BuyerInfo> SaveBuyerInfo(BuyerInfo model);
        Task<int> UpdateBuyerInfo(BuyerInfo model);
        Task DeleteBuyerInfo(Guid id);
        Task<IEnumerable<AmortizationSchedule>> GetAmortizationScheduleByBuyerInfoId(Guid id);
        Task<IEnumerable<AmortizationSchedule>> CreateAmortizationSchedule(BuyerInfo model);
        Task DeleteAmortizationSchedule(Guid id);
    }
}
