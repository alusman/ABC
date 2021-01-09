using ABC.Core.Interfaces.Repositories;
using ABC.Core.Interfaces.Services;
using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class AmortizationScheduleService : IAmortizationScheduleService
    {
        private readonly IAmortizationScheduleRepository _amortizationScheduleRepository;
        public AmortizationScheduleService(IAmortizationScheduleRepository amortizationScheduleRepository)
        {
            _amortizationScheduleRepository = amortizationScheduleRepository ?? throw new ArgumentNullException($"{nameof(amortizationScheduleRepository)} is required");
        }

        public async Task<IEnumerable<AmortizationSchedule>> GetAmortizationScheduleByBuyerInfoId(Guid buyerInfoId)
        {
            var result = await _amortizationScheduleRepository.GetAmortizationScheduleByBuyerInfoId(buyerInfoId).ConfigureAwait(false);
            if (result == null) return null;

            return result.ToList();
        }

        public async Task<IEnumerable<AmortizationSchedule>> CreateSchedule(BuyerInfo buyerInfo)
        {
            if (buyerInfo.Id == Guid.Empty) return null;

            var amortizationSchedule = BuildSchedule(buyerInfo);

            await _amortizationScheduleRepository.InsertSet(amortizationSchedule);

            return amortizationSchedule;
        }

        public async Task<bool> DeleteSchedule(Guid buyerInfoId) => await _amortizationScheduleRepository.DeleteByBuyerInfoId(buyerInfoId).ConfigureAwait(false);

        private List<AmortizationSchedule> BuildSchedule(BuyerInfo model)
        {
            // initial values
            var date = model.StartOfPayment;
            var noOfDays = (date - DateTime.Now).TotalDays;
            var rate = (decimal)(model.InterestRate / 100);
            var interest = model.LoanAmount * (decimal)noOfDays * rate / 365;
            var principal = model.LoanAmount / model.Term;
            var balance = model.LoanAmount - principal;

            var schedule = new List<AmortizationSchedule>();
            schedule.Add(new AmortizationSchedule()
            {
                PersonUnitId = model.Id,
                Date = date,
                Principal = principal,
                Interest = interest,
                LoanAmount = model.LoanAmount,
                NoOfDays = noOfDays,
                Total = principal + interest,
                Balance = balance
            });

            for (var i = 1; i < model.Term; i++)
            {
                // succeeding values
                date = schedule[i - 1].Date.AddMonths(1);
                noOfDays = (date - schedule[i - 1].Date).TotalDays;
                interest = schedule[i - 1].Balance * (decimal)noOfDays * rate / 365;
                balance = schedule[i - 1].Balance - principal;

                var item = new AmortizationSchedule()
                {
                    PersonUnitId = model.Id,
                    Date = date,
                    Principal = principal,
                    Interest = interest,
                    LoanAmount = model.LoanAmount,
                    NoOfDays = noOfDays,
                    Total = principal + interest,
                    Balance = balance
                };

                schedule.Add(item);
            }

            return schedule;
        }
    }
}
