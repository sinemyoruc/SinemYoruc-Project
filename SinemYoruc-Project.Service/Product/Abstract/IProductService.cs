using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using System.Collections.Generic;

namespace SinemYoruc_Project.Service
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {
        public BaseResponse<Product> ProductDetails(ProductDetail productDetail);
        public BaseResponse<Product> SoldProducts(int id);
    }
}
