﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Route.Talabat.APIs.Controllers.DTO;
using Talabat.core.Entities;
using Talabat.core.Repositories;
using Talabat.core.Specifications;

namespace Route.Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : APIBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> ProductRepo,IMapper mapper)
        {
            _productRepo = ProductRepo;
            _mapper = mapper;
        }
        // Get all product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var Spec = new ProductWithBrandAndTypeSpecification();
            var Products = await _productRepo.GetAllWithSpecAsync(Spec);
            var MappedProducts=_mapper.Map< IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(Products);
            return Ok(MappedProducts);
        }

        // Get product by Id
        [HttpGet("{id}")]
        public async Task<ActionResult>GetProduct(int id) 
        {
              var Spec = new ProductWithBrandAndTypeSpecification(id);
              var Product = await _productRepo.GetByIdWithSpecAsync(Spec);
              var MappedProduct =_mapper.Map<Product, ProductToReturnDto>(Product);
            return Ok(MappedProduct);
         }
     }
}
