using Hangfire;
using Microsoft.AspNetCore.Mvc;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Dto;
using SinemYoruc_Project.Hangfire;
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
            MailDto mail = new MailDto();
            mail.Subject = "Welcome";
            mail.ToEmail = request.Email;
            mail.Body = "Welcome";
            var response = tokenService.GenerateToken(request);
            BackgroundJob.Schedule(() => JobDelayed.SendEmailAsync(mail), TimeSpan.FromSeconds(25));
            return response;
        }


    }
}
