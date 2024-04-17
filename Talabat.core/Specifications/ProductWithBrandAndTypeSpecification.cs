using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.core.Specifications
{
    public class ProductWithBrandAndTypeSpecification:BaseSpecifications<Product>
    {
        public ProductWithBrandAndTypeSpecification():base()
        {
            Includes.Add(P => P.ProductType);
            Includes.Add(P => P.ProductBrand);

        }
    }
}
