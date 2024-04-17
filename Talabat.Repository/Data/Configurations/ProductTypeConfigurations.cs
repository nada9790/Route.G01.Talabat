using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.Repository.Data.Configurations
{
    public class ProductTypeConfigurations : IEntityTypeConfiguration<ProductType>
    {


        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(T => T.Name).IsRequired();
        }

    }
}
