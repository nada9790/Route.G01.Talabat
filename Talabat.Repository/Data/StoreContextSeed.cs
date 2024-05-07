using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Entities.Order_Aggregate;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync( StoreContext _dbContext)
        {
            if (!_dbContext.ProductBrands.Any())
            {
                var BrandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                if (Brands?.Count > 0)
                {
                    foreach (var Brand in Brands)
                    {
                      await  _dbContext.Set<ProductBrand>().AddAsync(Brand);
                    }
                    await _dbContext.SaveChangesAsync();
                }  
            }
            if (!_dbContext.ProductTypes.Any())
            {
                var TypesData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/types.json");
                var Types= JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                if (Types?.Count > 0)
                {
                    foreach (var Type in Types)
                    {
                        await _dbContext.Set<ProductType>().AddAsync(Type);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
            if (!_dbContext.Products.Any())
            {
                var ProductsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
                var Products= JsonSerializer.Deserialize<List<Product>>(ProductsData);

                if (Products?.Count > 0)
                {
                    foreach (var Product in Products)
                    {
                        await _dbContext.Set<Product>().AddAsync(Product);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
            //if (!_dbContext.DeliveryMethods.Any())
            //{
            //    var DeliveryMethodsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/delivery.json");
            //    var DeliveryMethods = JsonSerializer.Deserialize<List<Product>>(DeliveryMethod);

            //    if (DeliveryMethod?.Count > 0)
            //    {
            //        foreach (var DeliveryMethod in DeliveryMethods)
            //        {
            //            object value = await _dbContext.Set<DeliveryMethod>().AllAsync(DeliveryMethod);
            //        }
            //        await _dbContext.SaveChangesAsync();
            //    }
            //}
        }

    }
}
