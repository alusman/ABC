using ABC.Core.Models;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Services
{
    public interface IAmortizationScheduleService
    {
        Task<AmortizationSchedule> BuildSchedule(BuyerInfo model);
        Task<AmortizationSchedule> SaveSchedule(AmortizationSchedule model);
    }
}
