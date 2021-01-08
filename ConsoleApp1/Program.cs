using ABC.Core.Models;
using ABC.Infrastructure;
using ABC.Services;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertAmortizationSet();
            //InsertAmortizationSchedule();
            //UpdateAmortizationSchedule();
            //GetAllAmortizationSchedule();
            //GetAmortizationScheduleById();
            //GetAmortizationScheduleByBuyerInfoId();
            //DeleteAmortizationSchedule();

            //InsertBuyerInfo();
            //UpdateBuyerInfo();
            //GetAllBuyerInfo();
            //GetBuyerInfoById();
            //DeleteBuyerInfo();

            Console.ReadLine();
        }

        public async static void InsertAmortizationSet()
        {
            var Id = Guid.Parse("0B1F1A69-95FA-49E4-B1D0-96CE558715F7");
            var PersonId = Guid.Parse("6A450C84-71C5-4BC7-8DC4-B15FC21D0326");
            var UnitId = Guid.Parse("CEB434E6-A83F-416D-B0AF-9D61B5503006");

            var buyerInfo = new BuyerInfo()
            {
                Id = Id,
                PersonId = PersonId,
                UnitId = UnitId,
                Name = "John Doe",
                Address = "Paranaque City",
                ProjectName = "Mahogany",
                CondoUnit = "701",
                LoanAmount = 10000000.00M,
                Term = 360,
                StartOfPayment = DateTime.UtcNow.AddDays(2),
                InterestRate = 10F
            };

            var repo = new AmortizationScheduleRepository();
            var service = new AmortizationScheduleService(repo);

            var result = await service.CreateSchedule(buyerInfo);

            Console.WriteLine("Count: " + result.AmortizationSchedule.Count);
        }

        public async static void InsertAmortizationSchedule()
        {
            var schedule = new AmortizationSchedule()
            {
                Date = DateTime.UtcNow,
                Principal = 100000M,
                Interest = 5.0M,
                Total = 1250000M,
                Balance = 120000M,
                LoanAmount = 1200000M,
                NoOfDays = 10950,
            };

            var repo = new AmortizationScheduleRepository();
            var result = await repo.Insert(schedule);

            Console.WriteLine(result);
        }

        public async static void UpdateAmortizationSchedule()
        {
            var schedule = new AmortizationSchedule()
            {
                Id = Guid.Parse("CF3050EE-2487-4FB4-A5F3-4BD4E716AB05"),
                Date = DateTime.UtcNow,
                Principal = 100000M,
                Interest = 8.0M,
                Total = 1250000M,
                Balance = 120000M,
                LoanAmount = 1200000M,
                NoOfDays = 5475
            };

            var repo = new AmortizationScheduleRepository();
            var result = await repo.Update(schedule);

            Console.WriteLine(result);
        }

        public async static void GetAllAmortizationSchedule()
        {
            var repo = new AmortizationScheduleRepository();
            var result = await repo.GetAll();

            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Date);
                Console.WriteLine(item.Principal);
                Console.WriteLine(item.Interest);
                Console.WriteLine(item.Total);
                Console.WriteLine(item.Balance);
                Console.WriteLine(item.LoanAmount);
                Console.WriteLine(item.NoOfDays);
                Console.WriteLine("----------------------");
            }
        }

        public async static void GetAmortizationScheduleById()
        {
            var id = Guid.Parse("CF3050EE-2487-4FB4-A5F3-4BD4E716AB05");
            var repo = new AmortizationScheduleRepository();
            var result = await repo.GetById(id);

            Console.WriteLine(result.Id);
            Console.WriteLine(result.Date);
            Console.WriteLine(result.Principal);
            Console.WriteLine(result.Interest);
            Console.WriteLine(result.Total);
            Console.WriteLine(result.Balance);
            Console.WriteLine(result.LoanAmount);
            Console.WriteLine(result.NoOfDays);
        }

        public async static void GetAmortizationScheduleByBuyerInfoId()
        {
            var id = Guid.Parse("0B1F1A69-95FA-49E4-B1D0-96CE558715F7");
            var repo = new AmortizationScheduleRepository();
            var result = await repo.GetAmortizationScheduleByBuyerInfoId(id);

            Console.WriteLine(result.ToList().Count());
        }

        public async static void DeleteAmortizationSchedule()
        {
            var id = Guid.Parse("BD6A6A50-46B8-4C95-B019-D2C449520C1C");
            var repo = new AmortizationScheduleRepository();
            var result = await repo.Delete(id);
            Console.WriteLine(result);
        }

        public async static void InsertBuyerInfo()
        {
            var buyerInfo = new BuyerInfo() {
                Name = "Jane Doe",
                Address = "Paranaque",
                ProjectName = "Calathea",
                CondoUnit = "505",
                LoanAmount = 1000000.00M,
                Term = 10,
                StartOfPayment = DateTime.UtcNow,
                InterestRate = 6.5F
            };

            var repo = new BuyerInfoRepository();
            var result = await repo.Insert(buyerInfo);

            Console.WriteLine(result);
        }

        public async static void UpdateBuyerInfo()
        {
            var Id = Guid.Parse("0B1F1A69-95FA-49E4-B1D0-96CE558715F7");
            var PersonId = Guid.Parse("6A450C84-71C5-4BC7-8DC4-B15FC21D0326");
            var UnitId = Guid.Parse("CEB434E6-A83F-416D-B0AF-9D61B5503006");

            var buyerInfo = new BuyerInfo()
            {
                Id = Id,
                PersonId = PersonId,
                Name = "John Doe",
                Address = "Paranaque City",
                UnitId = UnitId,
                ProjectName = "Rapsody",
                CondoUnit = "701",
                LoanAmount = 5000000.00M,
                Term = 30,
                StartOfPayment = DateTime.UtcNow,
                InterestRate = 9.5F
            };

            var repo = new BuyerInfoRepository();
            var result = await repo.Update(buyerInfo);

            Console.WriteLine(result);
        }

        public async static void GetAllBuyerInfo()
        {
            var repo = new BuyerInfoRepository();
            var result = await repo.GetAll();

            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.PersonId);
                Console.WriteLine(item.UnitId);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.ProjectName);
                Console.WriteLine(item.CondoUnit);
                Console.WriteLine(item.LoanAmount);
                Console.WriteLine(item.Term);
                Console.WriteLine(item.InterestRate);
                Console.WriteLine("----------------------");
            }
        }

        public async static void GetBuyerInfoById()
        {
            var id = Guid.Parse("D8D45F0E-A484-4735-A8A6-689287E5C285");
            var repo = new BuyerInfoRepository();
            var res = await repo.GetById(id);

            Console.WriteLine(res.Id);
            Console.WriteLine(res.PersonId);
            Console.WriteLine(res.UnitId);
            Console.WriteLine(res.Name);
            Console.WriteLine(res.Address);
            Console.WriteLine(res.ProjectName);
            Console.WriteLine(res.CondoUnit);
            Console.WriteLine(res.LoanAmount);
            Console.WriteLine(res.Term);
            Console.WriteLine(res.InterestRate);
        }

        public async static void DeleteBuyerInfo()
        {
            var id = Guid.Parse("D8D45F0E-A484-4735-A8A6-689287E5C285");
            var repo = new BuyerInfoRepository();
            var result = await repo.Delete(id);
            Console.WriteLine(result);
        }
    }
}
