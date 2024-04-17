using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Repositories;
using Talabat.core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        public GenericRepository(StoreContext dbContext) 
        { 
          _dbContext= dbContext;
        }
        #region  Withot Spesification
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {

                return (IEnumerable<T>)await _dbContext.Products.Include(P => P.ProductBrand).Include(P => P.ProductType).ToListAsync();
            }
            return await _dbContext.Set<T>().ToListAsync();
        }



        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        #endregion


        #region With Spesification
        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpesifcations<T> Spec)
        {
            return await ApplySpesification(Spec).ToListAsync();
        }
        public async Task<T> GetByIdWithSpecAsync(ISpesifcations<T> Spec)
        {
            return await ApplySpesification(Spec).FirstOrDefaultAsync();   
        } 

        private IQueryable<T> ApplySpesification(ISpesifcations<T> Spec)
        {
            return SpesificationEvaluater<T>.GetQuery(_dbContext.Set<T>(), Spec);
        }
        #endregion
    }
}
