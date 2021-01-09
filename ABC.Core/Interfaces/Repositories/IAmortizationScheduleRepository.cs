using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Repositories
{
    public interface IAmortizationScheduleRepository 
    {
        Task<int> InsertSet(List<AmortizationSchedule> amortizations);
        Task<IEnumerable<AmortizationSchedule>> GetAmortizationScheduleByBuyerInfoId(Guid id);
        Task<bool> DeleteByBuyerInfoId(Guid buyerInfoId);
    }
}
