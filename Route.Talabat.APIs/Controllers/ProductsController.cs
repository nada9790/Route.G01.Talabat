using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.core.Entities;
using Talabat.core.Repositories;

namespace Route.Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : APIBaseController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductsController(IGenericRepository<Product> ProductRepo)
        {
            _productRepo = ProductRepo;
        }
        // Get all product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            var Products = await _productRepo.GetAllAsync();
            return Ok(Products);
        }

        // Get product by Id
        [HttpGet("{id}")]
        public async Task<ActionResult>GetProduct(int id) 
        { 

              var Product = await _productRepo.GetByIdAsync(id);
            return Ok(Product);
         }
     }
}
