using Talabat.core.Entities;

namespace Route.Talabat.APIs.Controllers.DTO
{
    public class ProductToReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int ProductBrandId { get; set; }//Fk
        public string ProductBrand { get; set; }
        public int ProductTypeId { get; set; }//FK
        public string ProductType { get; set; }
    }
}
