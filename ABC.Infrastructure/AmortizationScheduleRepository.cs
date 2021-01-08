using System;
using System.Data;
using ABC.Core.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using ABC.Core.Models;

namespace ABC.Infrastructure
{
    public class AmortizationScheduleRepository : IAmortizationScheduleRepository
    {
        private const string CONNECTION_STRING_NAME = "ABC";
        
        public async Task<IEnumerable<AmortizationSchedule>> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = "select * from AmortizationSchedule";

                return await connection.QueryAsync<AmortizationSchedule>(sql).ConfigureAwait(false);
            }
        }

        public async Task<AmortizationSchedule> GetById(Guid id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = "select * from AmortizationSchedule where Id = @Id";
                
                var param = new { Id = id };

                var result = await connection.QueryAsync<AmortizationSchedule>(sql, param).ConfigureAwait(false);

                return result.FirstOrDefault();
            }
        }

        public async Task<Guid> Insert(AmortizationSchedule model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = "dbo.InsertAmortizationSchedule";
                
                var param = new DynamicParameters();
                param.Add("@PersonUnitId", model.BuyerInfo.Id);
                param.Add("@Principal", model.Principal);
                param.Add("@Interest", model.Interest);
                param.Add("@LoanAmount", model.LoanAmount);
                param.Add("@NoOfDays", model.NoOfDays);
                param.Add("@Total", model.Total);
                param.Add("@Balance", model.Balance);
                param.Add("@Id", null, DbType.Guid, ParameterDirection.Output);

                await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                var result = param.Get<Guid>("@Id");

                return result;
            }
        }

        public async Task<int> Update(AmortizationSchedule model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = "dbo.UpdateAmortizationSchedule";
                
                var param = new DynamicParameters();
                param.Add("@Id", model.Id);
                param.Add("@PersonUnitId", model.BuyerInfo.Id);
                param.Add("@Principal", model.Principal);
                param.Add("@Interest", model.Interest);
                param.Add("@LoanAmount", model.LoanAmount);
                param.Add("@NoOfDays", model.NoOfDays);
                param.Add("@Total", model.Total);
                param.Add("@Balance", model.Balance);

                return await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false); // return rows affected
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = "delete from AmortizationSchedule where Id = @Id";

                var param = new { Id = id };

                var result = await connection.ExecuteAsync(sql, param).ConfigureAwait(false);

                return result > 0; // check if any row as been affected
            }
        }
    }
}
