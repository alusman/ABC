using ABC.Core.Interfaces.Repositories;
using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace ABC.Infrastructure
{
    public class BuyerInfoRepository : IBuyerInfoRepository
    {
        private const string CONNECTION_STRING_NAME = "ABC";

        public async Task<IEnumerable<BuyerInfo>> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = @"select b.Id, a.*, c.* from Person a
                            join PersonUnit b on a.Id = b.PersonId
                            join Unit c on b.UnitId = c.Id";

                return await connection.QueryAsync<Entities.PersonUnit, Entities.Person, BuyerInfo, BuyerInfo>(sql,
                    (personUnit, person, buyerInfo) => {
                        buyerInfo.Id = personUnit.Id;
                        buyerInfo.PersonId = person.Id;
                        buyerInfo.Name = person.Name; 
                        buyerInfo.Address = person.Address;
                        buyerInfo.UnitId = personUnit.UnitId;
                        return buyerInfo;
                    }).ConfigureAwait(false);
            }
        }

        public async Task<BuyerInfo> GetById(Guid id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = $@"select b.Id, a.*, c.* from Person a
                            join PersonUnit b on a.Id = b.PersonId
                            join Unit c on b.UnitId = c.Id
                            where b.Id = @Id";

                var param = new { Id = id };

                var result = await connection.QueryAsync<Entities.PersonUnit, Entities.Person, BuyerInfo, BuyerInfo>(sql,
                    (personUnit, person, buyerInfo) => {
                        buyerInfo.Id = personUnit.Id;
                        buyerInfo.PersonId = person.Id;
                        buyerInfo.Name = person.Name;
                        buyerInfo.Address = person.Address;
                        buyerInfo.UnitId = personUnit.UnitId;
                        return buyerInfo;
                    }, param).ConfigureAwait(false);

                return result.FirstOrDefault();
            }
        }

        public async Task<Guid> Insert(BuyerInfo model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = $"dbo.InsertPerson @Name @Address";

                var param = new DynamicParameters();
                param.Add("@Name", model.Name);
                param.Add("@Address", model.Address);
                param.Add("@Id", null, DbType.Guid, ParameterDirection.Output);

                var sql2 = $"dbo.InsertUnit @ProjectName @CondoUnit @LoanAmount @Term @StartOfPayment @InterestRate";

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
                        var unitId = param.Get<Guid>("@Id");

                        // setup PersonUnit
                        var sql3 = $"dbo.InsertPersonUnit @PersonId @UnitId";

                        var param3 = new DynamicParameters();
                        param3.Add("@PersonId", personId);
                        param3.Add("@UnitId", unitId);
                        param3.Add("@Id", null, DbType.Guid, ParameterDirection.Output);

                        // insert PersonUnit
                        await connection.ExecuteAsync(sql3, param3, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                        var result = param.Get<Guid>("@Id");

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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = $"dbo.UpdatePerson @Id @Name @Address";

                var param = new DynamicParameters();
                param.Add("@Id", model.PersonId);
                param.Add("@Name", model.Name);
                param.Add("@Address", model.Address);
                
                var sql2 = $"dbo.UpdateUnit @Id @ProjectName @CondoUnit @LoanAmount @Term @StartOfPayment @InterestRate";

                var param2 = new DynamicParameters();
                param2.Add("@Id", model.UnitId);
                param2.Add("@ProjectName", model.ProjectName);
                param2.Add("@CondoUnit", model.CondoUnit);
                param2.Add("@LoanAmount", model.LoanAmount);
                param2.Add("@Term", model.Term);
                param2.Add("@StartOfPayment", model.StartOfPayment);
                param2.Add("@InterestRate", model.InterestRate);

                var sql3 = $"dbo.UpdatePersonUnit @PersonId @UnitId";

                var param3 = new DynamicParameters();
                param3.Add("@Id", model.Id);
                param3.Add("@PersonId", model.PersonId);
                param3.Add("@UnitId", model.UnitId);
                

                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(sql, param, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                        await connection.ExecuteAsync(sql2, param2, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                        await connection.ExecuteAsync(sql3, param3, trans, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                        trans.Commit();

                        return 1;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }

                return 0;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            // also delete Person and Unit here or do it on the service level after executing this?
            // deletion of Person and Unit not yet implemented anywhere
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = $"delete from dbo.PersonUnit where Id = @Id";

                var param = new { Id = id };

                var result = await connection.ExecuteAsync(sql, param).ConfigureAwait(false);

                return result > 0;
            }
        }
    }
}
