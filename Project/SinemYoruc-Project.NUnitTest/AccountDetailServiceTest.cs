using AutoMapper;
using NHibernate;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.NUnitTest
{
    public class AccountDetailServiceTest
    {
        IAccountDetailService accountDetailService;
        ISession session;
        IMapper mapper;

        [SetUp]
        public void Setup()
        {
            accountDetailService = new AccountDetailService(session, mapper);
        }


        [Test]
        public void ProductService_Test()
        {

        }
    }
}
