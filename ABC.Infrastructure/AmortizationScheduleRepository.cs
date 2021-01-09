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
        
        public async Task<IEnumerable<AmortizationSchedule>> GetAmortizationScheduleByBuyerInfoId(Guid id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = "select * from AmortizationSchedule where PersonUnitId = @Id";

                var param = new { Id = id };

                return await connection.QueryAsync<AmortizationSchedule>(sql, param).ConfigureAwait(false);
            }
        }

        public async Task<int> InsertSet(List<AmortizationSchedule> amortizations)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = "dbo.InsertAmortizationScheduleSet";

                var param = new
                {
                    set = MapToDataTable(amortizations).AsTableValuedParameter("AmortizationScheduleUDT")
                };

                // return number of records affected
                return await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public async Task<bool> DeleteByBuyerInfoId(Guid buyerInfoId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING_NAME)))
            {
                var sql = "delete from AmortizationSchedule where PersonUnitId = @Id";

                var param = new { Id = buyerInfoId };

                var result = await connection.ExecuteAsync(sql, param).ConfigureAwait(false);

                return result > 0; // return if any row has been affected
            }
        }

        private DataTable MapToDataTable(List<AmortizationSchedule> amortizations)
        {
            var result = new DataTable();

            result.Columns.Add("PersonUnitId", typeof(Guid));
            result.Columns.Add("Date", typeof(DateTime));
            result.Columns.Add("Principal", typeof(decimal));
            result.Columns.Add("Interest", typeof(decimal));
            result.Columns.Add("LoanAmount", typeof(decimal));
            result.Columns.Add("NoOfDays", typeof(int));
            result.Columns.Add("Total", typeof(decimal));
            result.Columns.Add("Balance", typeof(decimal));

            foreach (var item in amortizations)
            {
                result.Rows.Add(item.PersonUnitId, item.Date, item.Principal, item.Interest, item.LoanAmount, item.NoOfDays, item.Total, item.Balance);
            }

            return result;
        }
    }
}
