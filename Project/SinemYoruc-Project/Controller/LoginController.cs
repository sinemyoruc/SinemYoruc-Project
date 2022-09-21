using Microsoft.AspNetCore.Mvc;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.Controller
{
    [ApiController]
    [Route("api")]
    public class LoginController
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost("Login")]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = loginService.GenerateToken(request);
            return response;
        }
    }
}
