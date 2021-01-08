using ABC.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Repositories
{
    public interface IAmortizationScheduleRepository : IRepositoryBase<AmortizationSchedule>
    {
        Task<int> InsertSet(List<AmortizationSchedule> amortizations);
    }
}
