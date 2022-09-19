using AutoMapper;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;

namespace SinemYoruc_Project.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductDetailDto, ProductDetail>().ReverseMap();
        }

    }
}
