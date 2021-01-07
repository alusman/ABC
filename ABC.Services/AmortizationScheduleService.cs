using ABC.Core.Interfaces.Services;
using ABC.Core.Models;
using System;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class AmortizationScheduleService : IAmortizationScheduleService
    {
        public Task<AmortizationSchedule> BuildSchedule(BuyerInfo model)
        {
            throw new NotImplementedException();
        }
    }
}
