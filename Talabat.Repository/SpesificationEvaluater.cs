using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Specifications;

namespace Talabat.Repository
{
    public static class SpesificationEvaluater<T> where T:BaseEntity 
    {
        public static IQueryable<T> GetQuery (IQueryable<T> inputQuery, ISpesifcations<T> Spec)
        {
            var Query = inputQuery;
            if (Spec.Criteria is not null)
            {
               Query=Query.Where(Spec.Criteria);
            }
            Query=Spec.Includes.Aggregate(Query,(CurrentQuery,IncludeExpression)=>CurrentQuery.Include(IncludeExpression));


            return Query;
        }
        
       
    }
}
