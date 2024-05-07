﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities.Order_Aggregate;

namespace Talabat.Repository.Data.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.Property(O=>O.Status)
                .HasConversion(OStatus=>OStatus.ToString(),OStatus=>(OrderStatus) Enum.Parse(typeof(OrderStatus),OStatus));
            builder.Property(O => O.SubTotal)
                .HasColumnType("decimal(18,2)");
            builder.OwnsOne(O => O.ShippingAddress, X => X.WithOwner());
            builder.HasOne(O => O.DeliveryMethod)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}