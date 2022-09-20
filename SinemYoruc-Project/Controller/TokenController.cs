using Microsoft.AspNetCore.Mvc;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Service;
using System;

namespace SinemYoruc_Project.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }


        [HttpPost("Login")]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenService.GenerateToken(request);
            return response;
        }


    }
}
