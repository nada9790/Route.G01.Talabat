﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.Repository.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.ProductBrand)
                .WithMany()
                .HasForeignKey(P => P.ProductBrandId);

            builder.HasOne(P => P.ProductType)
                .WithMany()
                .HasForeignKey(P => P.ProductTypeId);
            builder.Property(P => P.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(P => P.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(P => P.PictureUrl)
                .IsRequired();
          

        }
    }
       
   
}
  