using AutoMapper;
using Route.Talabat.APIs.Controllers.DTO;
using Talabat.core.Entities;

namespace Route.Talabat.APIs.Controllers.Helpers
{
    public class MappingProfiles:Profile
    {
       public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                      .ForMember(d =>d .ProductType, O=>O.MapFrom(S=>S.ProductType.Name))
                      .ForMember(d => d.ProductBrand, O => O.MapFrom(S => S.ProductBrand.Name));
        }

    }
}
