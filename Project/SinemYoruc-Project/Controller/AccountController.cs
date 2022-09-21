using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using SinemYoruc_Project.Service;
using System.Collections.Generic;

namespace SinemYoruc_Project.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController<AccountDto, Account>
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;


        public AccountController(IAccountService accountService, IMapper mapper) : base(accountService, mapper)
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }

        [HttpGet("GetProduct")]
        public BaseResponse<IEnumerable<Product>> GetProduct(int id) //The method that lists the user's products 
        {
            var response = accountService.GetProduct(id);
            return response;
        }

        [HttpGet("GetOfferProduct")]
        public BaseResponse<IEnumerable<ProductsOffer>> GetOfferProduct(int id) //The method that lists the offers user made
        {
            var response = accountService.GetOfferProduct(id);
            return response;
        }


        [HttpGet("RecievedOffer")]
        public BaseResponse<Product> RecievedOffer(int id) //The method that lists the offers user received
        {
            var response = accountService.RecievedOffer(id);
            return response;
        }

        [HttpGet("AcceptOffer")]
        public BaseResponse<Product> AcceptOffer(int id) //The method that lists the offers user received
        {
            var response = accountService.AcceptOffer(id);
            return response;
        }

        [HttpGet("RefuseOffer")]
        public BaseResponse<Product> RefuseOffer(int id)
        {
            var response = accountService.RefuseOffer(id);
            return response;
        }
    }
}
