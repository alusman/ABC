using ABC.Core.Interfaces.Services;
using ABC.Core.Models;
using ABC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class BuyerAmortizationService : IBuyerAmortizationService
    {
        private readonly IBuyerInfoService _buyerInfoService;
        private readonly IAmortizationScheduleService _amortizationScheduleService;
        public BuyerAmortizationService(IBuyerInfoService buyerInfoService, IAmortizationScheduleService amortizationScheduleService)
        {
            _buyerInfoService = buyerInfoService ?? throw new ArgumentNullException($"{nameof(buyerInfoService)} is required");
            _amortizationScheduleService = amortizationScheduleService ?? throw new ArgumentNullException($"{nameof(amortizationScheduleService)} is required");
        }

        public async Task<IEnumerable<BuyerInfo>> GetAllBuyerInfo()
        {
            var result = await _buyerInfoService.GetAllBuyerInfo().ConfigureAwait(false);
            if (result == null) return null;

            return result;
        }

        public async Task<BuyerInfo> GetBuyerInfoById(Guid id)
        {
            var result = await _buyerInfoService.GetBuyerInfoById(id).ConfigureAwait(false);
            if (result == null) return null;

            return result;
        }

        public async Task<BuyerInfo> SaveBuyerInfo(BuyerInfo model)
        {
            var id = await _buyerInfoService.SaveBuyerInfo(model).ConfigureAwait(false);
            var result = await _buyerInfoService.GetBuyerInfoById(id).ConfigureAwait(false);
            if (result == null) return null;

            return result;
        }

        public async Task<int> UpdateBuyerInfo(BuyerInfo model)
        {
            // should I regenerate schedule when updated?
            var result = await _buyerInfoService.UpdateBuyerInfo(model).ConfigureAwait(false);

            return result;
        }

        public async Task DeleteBuyerInfo(Guid id)
        {
            await _amortizationScheduleService.DeleteSchedule(id).ConfigureAwait(false);
            await _buyerInfoService.DeleteBuyerInfo(id).ConfigureAwait(false);

            return;
        }

        public async Task<IEnumerable<AmortizationSchedule>> GetAmortizationScheduleByBuyerInfoId(Guid id)
        {
            var result = await _amortizationScheduleService.GetAmortizationScheduleByBuyerInfoId(id).ConfigureAwait(false);
            if (result == null) return null;

            return result;
        }

        public async Task<IEnumerable<AmortizationSchedule>> CreateAmortizationSchedule(BuyerInfo model)
        {
            var buyerInfoId = model.Id;
            if (buyerInfoId == Guid.Empty)
            {
                // should I also return the BuyerInfo if saved
                buyerInfoId = await _buyerInfoService.SaveBuyerInfo(model).ConfigureAwait(false);
                if (buyerInfoId == null) return null;

                model.Id = buyerInfoId;
            }
            // what to do if buyer info was also updated?

            // delete any existing records before generating a new schedule
            await _amortizationScheduleService.DeleteSchedule(model.Id).ConfigureAwait(false);

            var result = await _amortizationScheduleService.CreateSchedule(model).ConfigureAwait(false);
            if (result == null) return null;

            return result;
        }

        public async Task DeleteAmortizationSchedule(Guid id)
        {
            await _amortizationScheduleService.DeleteSchedule(id).ConfigureAwait(false);

            return;
        }
    }
}
