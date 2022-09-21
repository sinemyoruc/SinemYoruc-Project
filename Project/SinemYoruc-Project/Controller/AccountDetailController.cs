using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using System.Collections.Generic;

namespace SinemYoruc_Project.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountDetailController
    {
        private readonly IAccountDetailService accountService;
        private readonly IMapper mapper;

        public AccountDetailController(IAccountDetailService accountService, IMapper mapper)
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


        [HttpGet("GetRecievedOffer")]
        public BaseResponse<IEnumerable<Product>> GetRecievedOffer(int id) //The method that lists the offers user received
        {
            var response = accountService.GetRecievedOffer(id);
            return response;
        }

        [HttpPost("CreateAcceptOffer")]
        public BaseResponse<Product> CreateAcceptOffer(int id) //The method created for the user to accept offers
        {
            var response = accountService.CreateAcceptOffer(id);
            return response;
        }

        [HttpPost("CreateRefuseOffer")]
        public BaseResponse<Product> CreateRefuseOffer(int id) //The method created for the user to refuse offers
        {
            var response = accountService.CreateRefuseOffer(id);
            return response;
        }

    }
}
