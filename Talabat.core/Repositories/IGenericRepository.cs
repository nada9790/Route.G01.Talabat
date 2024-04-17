using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Specifications;

namespace Talabat.core.Repositories
{
    public interface IGenericRepository<T>  where T : BaseEntity
    {
        #region Without Spesification
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        #endregion

        #region With Spesification
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpesifcations<T> Spec);
        Task<T> GetByIdWithSpecAsync(ISpesifcations<T> Spec);
        #endregion
    }
}
