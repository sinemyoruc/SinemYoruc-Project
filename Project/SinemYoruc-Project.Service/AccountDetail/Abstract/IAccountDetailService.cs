using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using System.Collections.Generic;

namespace SinemYoruc_Project
{
    public interface IAccountDetailService
    {
        public BaseResponse<IEnumerable<Product>> GetProduct(int id);
        public BaseResponse<IEnumerable<ProductsOffer>> GetOfferProduct(int id);
        public BaseResponse<IEnumerable<Product>> GetRecievedOffer(int id);
        public BaseResponse<Product> CreateAcceptOffer(int id);
        public BaseResponse<Product> CreateRefuseOffer(int id);
    }
}
