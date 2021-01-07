using ABC.Core.Interfaces.Repositories;
using ABC.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Infrastructure
{
    public class BuyerInfoRepository : IBuyerInfoRepository
    {
        public Task<bool> Delete(BuyerInfo model)
        {
            throw new NotImplementedException();
        }

        public Task<List<BuyerInfo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BuyerInfo> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Insert(BuyerInfo model)
        {
            throw new NotImplementedException();
        }

        public Task Update(BuyerInfo model)
        {
            throw new NotImplementedException();
        }
    }
}
