using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<Guid> Insert(T model);
        Task<int> Update(T model);
        Task<Boolean> Delete(Guid id);
    }
}
