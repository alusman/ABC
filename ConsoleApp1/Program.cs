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
            //InsertAmortizationSet();;
            //GetAmortizationScheduleByBuyerInfoId();
            //DeleteAmortizationScheduleByBuyerInfoId();

            //InsertBuyerInfo();
            //UpdateBuyerInfo();
            //GetAllBuyerInfo();
            //GetBuyerInfoById();
            //DeleteBuyerInfo();

            Console.ReadLine();
        }

        //public async static void InsertAmortizationSet()
        //{
        //    var Id = Guid.Parse("A8289560-E9E0-48EB-9F45-FBD15B643CE7");
        //    var PersonId = Guid.Parse("52748B8C-AB89-41C0-BFA6-CE054829292F");
        //    var UnitId = Guid.Parse("5F507243-2246-4ADD-B547-BA93C807FC8D");

        //    var buyerInfo = new BuyerInfo()
        //    {
        //        Id = Id,
        //        PersonId = PersonId,
        //        UnitId = UnitId,
        //        Name = "John Doe",
        //        Address = "Paranaque City",
        //        ProjectName = "Mahogany",
        //        CondoUnit = "701",
        //        LoanAmount = 10000000.00M,
        //        Term = 1000,
        //        StartOfPayment = DateTime.UtcNow.AddDays(2),
        //        InterestRate = 10F
        //    };

        //    var repo = new AmortizationScheduleRepository();
        //    var service = new AmortizationScheduleService(repo);

        //    var result = await service.CreateSchedule(buyerInfo);

        //    Console.WriteLine("Count: " + result.ToList().Count);
        //}

        //public async static void GetAmortizationScheduleByBuyerInfoId()
        //{
        //    var Id = Guid.Parse("A8289560-E9E0-48EB-9F45-FBD15B643CE7");
        //    var repo = new AmortizationScheduleRepository();
        //    var result = await repo.GetAmortizationScheduleByBuyerInfoId(Id);

        //    Console.WriteLine(result.ToList().Count());
        //}

        //public async static void DeleteAmortizationScheduleByBuyerInfoId()
        //{
        //    var Id = Guid.Parse("A8289560-E9E0-48EB-9F45-FBD15B643CE7");
        //    var repo = new AmortizationScheduleRepository();
        //    var result = await repo.DeleteByBuyerInfoId(Id);
        //    Console.WriteLine(result);
        //}

        //public async static void InsertBuyerInfo()
        //{
        //    var buyerInfo = new BuyerInfo() {
        //        Name = "Jane Doe",
        //        Address = "Paranaque",
        //        ProjectName = "Calathea",
        //        CondoUnit = "505",
        //        LoanAmount = 1000000.00M,
        //        Term = 10,
        //        StartOfPayment = DateTime.UtcNow,
        //        InterestRate = 6.5F
        //    };

        //    var repo = new BuyerInfoRepository();
        //    var result = await repo.Insert(buyerInfo);

        //    Console.WriteLine(result);
        //}

        //public async static void UpdateBuyerInfo()
        //{
        //    var Id = Guid.Parse("A8289560-E9E0-48EB-9F45-FBD15B643CE7");
        //    var PersonId = Guid.Parse("52748B8C-AB89-41C0-BFA6-CE054829292F");
        //    var UnitId = Guid.Parse("5F507243-2246-4ADD-B547-BA93C807FC8D");

        //    var buyerInfo = new BuyerInfo()
        //    {
        //        Id = Id,
        //        PersonId = PersonId,
        //        Name = "John Doe",
        //        Address = "Paranaque City",
        //        UnitId = UnitId,
        //        ProjectName = "Rapsody",
        //        CondoUnit = "701",
        //        LoanAmount = 5000000.00M,
        //        Term = 10000,
        //        StartOfPayment = DateTime.UtcNow,
        //        InterestRate = 9.5F
        //    };

        //    var repo = new BuyerInfoRepository();
        //    var result = await repo.Update(buyerInfo);

        //    Console.WriteLine(result);
        //}

        //public async static void GetAllBuyerInfo()
        //{
        //    var repo = new BuyerInfoRepository();
        //    var result = await repo.GetAll();

        //    foreach (var item in result)
        //    {
        //        Console.WriteLine(item.Id);
        //        Console.WriteLine(item.PersonId);
        //        Console.WriteLine(item.UnitId);
        //        Console.WriteLine(item.Name);
        //        Console.WriteLine(item.Address);
        //        Console.WriteLine(item.ProjectName);
        //        Console.WriteLine(item.CondoUnit);
        //        Console.WriteLine(item.LoanAmount);
        //        Console.WriteLine(item.Term);
        //        Console.WriteLine(item.InterestRate);
        //        Console.WriteLine("----------------------");
        //    }
        //}

        //public async static void GetBuyerInfoById()
        //{
        //    var Id = Guid.Parse("A8289560-E9E0-48EB-9F45-FBD15B643CE7");
        //    var repo = new BuyerInfoRepository();
        //    var res = await repo.GetById(Id);

        //    Console.WriteLine(res.Id);
        //    Console.WriteLine(res.PersonId);
        //    Console.WriteLine(res.UnitId);
        //    Console.WriteLine(res.Name);
        //    Console.WriteLine(res.Address);
        //    Console.WriteLine(res.ProjectName);
        //    Console.WriteLine(res.CondoUnit);
        //    Console.WriteLine(res.LoanAmount);
        //    Console.WriteLine(res.Term);
        //    Console.WriteLine(res.InterestRate);
        //}

        //public async static void DeleteBuyerInfo()
        //{
        //    var id = Guid.Parse("0B1F1A69-95FA-49E4-B1D0-96CE558715F7");
        //    var repo = new BuyerInfoRepository();
        //    var result = await repo.Delete(id);
        //    Console.WriteLine(result);
        //}
    }
}
