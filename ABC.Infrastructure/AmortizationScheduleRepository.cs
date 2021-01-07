using System;
using System.Data;
using ABC.Core;
using ABC.Core.Interfaces.Repositories;
using System.Threading.Tasks;
using ABC.Core.Models;
using System.Collections.Generic;
using Dapper;

namespace ABC.Infrastructure
{
    public class AmortizationScheduleRepository : IAmortizationScheduleRepository
    {
        // TODO: use the correct connection string
        private const string CONNECTION_STRING = "";
        
        public Task<List<AmortizationSchedule>> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(CONNECTION_STRING)))
            {

            }

            // TODO: remove this once implemented
            throw new NotImplementedException();
        }

        public Task<AmortizationSchedule> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Insert(AmortizationSchedule model)
        {
            throw new NotImplementedException();
        }

        public Task Update(AmortizationSchedule model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(AmortizationSchedule model)
        {
            throw new NotImplementedException();
        }
    }
}
