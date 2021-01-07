using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById();
        Task<Guid> Insert(T model);
        Task Update(T model);
        Task<Boolean> Delete(T model);
    }
}
