﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.Repository.Data.Configurations
{
    public class ProductBrandConfigurations: IEntityTypeConfiguration<ProductBrand>
    {
 

        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(B => B.Name).IsRequired();
        }
    }
}
