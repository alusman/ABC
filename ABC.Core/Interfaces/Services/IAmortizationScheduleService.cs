using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Services
{
    public interface IAmortizationScheduleService
    {
        Task<IEnumerable<AmortizationSchedule>> GetAmortizationScheduleByBuyerInfoId(Guid buyerInfoId);
        Task<IEnumerable<AmortizationSchedule>> CreateSchedule(BuyerInfo buyerInfo);
        Task<bool> DeleteSchedule(Guid buyerInfoId);
    }
}
