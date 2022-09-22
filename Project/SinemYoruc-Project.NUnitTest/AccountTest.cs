using AutoMapper;
using NHibernate;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.NUnitTest
{
    public class AccountTest
    {
        IAccountService accountService;
        ISession session;
        IMapper mapper;

        [SetUp]
        public void Setup()
        {
            accountService = new AccountService(session, mapper);
        }


        [Test]
        public void AccountService_Test()
        {

        }
    }
}
