using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;

namespace SinemYoruc_Project.Service
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {
        public BaseResponse<Product> ProductsOffer(ProductsOfferDto productDetail);
        public BaseResponse<Product> SoldProducts(int id);
    }
}
