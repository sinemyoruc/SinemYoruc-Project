using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using System.Collections.Generic;

namespace SinemYoruc_Project.Service
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {
        public BaseResponse<IEnumerable<Product>> GetProduct(int id);
        public BaseResponse<IEnumerable<ProductsOffer>> GetOfferProduct(int id);
        public BaseResponse<IEnumerable<Product>> RecievedOffer(int id);
        public BaseResponse<Product> AcceptOffer(int id);
        public BaseResponse<Product> RefuseOffer(int id);
    }
}
