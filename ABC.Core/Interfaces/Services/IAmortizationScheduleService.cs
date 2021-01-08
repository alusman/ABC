using ABC.Core.Models;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Services
{
    public interface IAmortizationScheduleService
    {
        Task<Amortization> CreateSchedule(BuyerInfo buyerInfo);
    }
}
