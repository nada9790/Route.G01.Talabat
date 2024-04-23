using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Repository.Data;

namespace Route.Talabat.APIs.Controllers
{

    public class BuggyController : APIBaseController
    {
        private readonly StoreContext _dbContext;

        public BuggyController(StoreContext dbcontext)
        {
            this._dbContext = dbcontext;
        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFoundRequest()
        {
            var Product = _dbContext.Products.Find(100);
            if (Product is null) return NotFound();
            return Ok(Product);
        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
            var Product = _dbContext.Products.Find(100);
            var ProductToReturn = Product.ToString();
            return Ok(ProductToReturn);
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {
            return (BadRequest());
        }


        [HttpGet("BadRequest/{id}")]
        public ActionResult GetbadRequest(int id)
        {
           
            return Ok();
        }
    }
}
