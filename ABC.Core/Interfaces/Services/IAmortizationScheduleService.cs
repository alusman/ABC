using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Services
{
    public interface IAmortizationScheduleService
    {
        Task<List<AmortizationSchedule>> GetAmortizationScheduleByBuyerInfoId(Guid buyerInfoId);
        Task<Amortization> CreateSchedule(BuyerInfo buyerInfo);
        Task<Amortization> GetAmortization(BuyerInfo buyerInfo);
    }
}
