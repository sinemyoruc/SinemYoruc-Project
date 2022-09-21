using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using SinemYoruc_Project.Service;

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
    }
}
