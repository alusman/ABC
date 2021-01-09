using ABC.Core.Interfaces.Repositories;
using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Microsoft.Extensions.Options;

namespace ABC.Infrastructure
{
    public class BuyerInfoRepository : IBuyerInfoRepository
    {
        private readonly IOptions<ConnectionOptions> _options;

        public BuyerInfoRepository(IOptions<ConnectionOptions> options)
        {
            _options = options ?? throw new ArgumentNullException($"{nameof(options)} is required");
        }

        public async Task<IEnumerable<BuyerInfo>> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_options.Value.DefaultConnection))
            {
                var sql = @"select b.Id, a.*, c.* from Person a
                            join PersonUnit b on a.Id = b.PersonId
                            join Unit c on b.UnitId = c.Id";

                return await connection.QueryAsync<Entities.PersonUnit, Entities.Person, Entities.Unit, BuyerInfo>(sql,
                    (personUnit, person, unit) => {
                        var res = new BuyerInfo()
                        {
                            Id = personUnit.Id,
                            PersonId = person.Id,
                            Name = person.Name,
                            Address = person.Address,
                            UnitId = unit.Id,
                            ProjectName = unit.ProjectName,
                            CondoUnit = unit.CondoUnit,
                            LoanAmount = unit.LoanAmount,
                            Term = unit.Term,
                            StartOfPayment = unit.StartOfPayment,
                            InterestRate = unit.InterestRate
                        };

                        return res;
                    }).ConfigureAwait(false);
            }
        }

        public async Task<BuyerInfo> GetById(Guid id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_options.Value.DefaultConnection))
            {
                var sql = $@"select b.Id, a.*, c.* from Person a
                            join PersonUnit b on a.Id = b.PersonId
                            join Unit c on b.UnitId = c.Id
                            where b.Id = @Id";

                var param = new { Id = id };

                var result = await connection.QueryAsync<Entities.PersonUnit, Entities.Person, Entities.Unit, BuyerInfo>(sql,
                    (personUnit, person, unit) => {
                        var res = new BuyerInfo()
                        {
                            Id = personUnit.Id,
                            PersonId = person.Id,
                            Name = person.Name,
                            Address = person.Address,
                            UnitId = unit.Id,
                            ProjectName = unit.ProjectName,
                            CondoUnit = unit.CondoUnit,
                            LoanAmount = unit.LoanAmount,
                            Term = unit.Term,
                            StartOfPayment = unit.StartOfPayment,
                            InterestRate = unit.InterestRate
                        };

                        return res;
                    }, param).ConfigureAwait(false);

                return result.FirstOrDefault();
            }
        }

        public async Task<Guid> Insert(BuyerInfo model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_options.Value.DefaultConnection))
            {
                var sql = "dbo.InsertPerson";

                var param = new DynamicParameters();
                param.Add("@Name", model.Name);
                param.Add("@Address", model.Address);
                param.Add("@Id", null, DbType.Guid, ParameterDirection.Output);

                var sql2 = $"dbo.InsertUnit";

                var param2 = new DynamicParameters();
                param2.Add("@ProjectName", model.ProjectName);
                param2.Add("@CondoUnit", model.CondoUnit);
                param2.Add("@LoanAmount", model.LoanAmount);
                param2.Add("@Term", model.Term);
                param2.Add("@StartOfPayment", model.StartOfPayment);
                param2.Add("@InterestRate", model.InterestRate);
                param2.Add("@Id", null, DbType.Guid, ParameterDirection.Output);

                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    try
                    {
                        // insert Person
                        await connection.ExecuteAsync(sql, param, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                        var personId = param.Get<Guid>("@Id");

                        // insert Unit
                        await connection.ExecuteAsync(sql2, param2, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                        var unitId = param2.Get<Guid>("@Id");

                        // setup PersonUnit
                        var sql3 = $"dbo.InsertPersonUnit";

                        var param3 = new DynamicParameters();
                        param3.Add("@PersonId", personId);
                        param3.Add("@UnitId", unitId);
                        param3.Add("@Id", null, DbType.Guid, ParameterDirection.Output);

                        // insert PersonUnit
                        await connection.ExecuteAsync(sql3, param3, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                        var result = param3.Get<Guid>("@Id");

                        trans.Commit();

                        return result;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }

                return Guid.Empty;
            }
        }

        public async Task<int> Update(BuyerInfo model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_options.Value.DefaultConnection))
            {
                var sql = "dbo.UpdatePerson";

                var param = new DynamicParameters();
                param.Add("@Id", model.PersonId);
                param.Add("@Name", model.Name);
                param.Add("@Address", model.Address);
                
                var sql2 = $"dbo.UpdateUnit";

                var param2 = new DynamicParameters();
                param2.Add("@Id", model.UnitId);
                param2.Add("@ProjectName", model.ProjectName);
                param2.Add("@CondoUnit", model.CondoUnit);
                param2.Add("@LoanAmount", model.LoanAmount);
                param2.Add("@Term", model.Term);
                param2.Add("@StartOfPayment", model.StartOfPayment);
                param2.Add("@InterestRate", model.InterestRate);
                               
                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(sql, param, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                        await connection.ExecuteAsync(sql2, param2, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return 0;
                    }
                }

                return 1;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_options.Value.DefaultConnection))
            {
                var query = $"select * from dbo.PersonUnit where Id = @Id";
                var param = new { Id = id };

                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    try
                    {
                        var buyerInfo = await connection.QueryAsync<Entities.PersonUnit>(query, param, trans).ConfigureAwait(false);
                        var toBeDeleted = buyerInfo.FirstOrDefault();

                        var sql = $@"delete from dbo.PersonUnit where Id = @Id;
                                     delete from dbo.Person where Id = @PersonId;
                                     delete from dbo.Unit where Id = @UnitId";

                        var ids = new { Id = id, PersonId = toBeDeleted.PersonId, UnitId = toBeDeleted.UnitId };

                        var result = await connection.ExecuteAsync(sql, ids, trans).ConfigureAwait(false);

                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
