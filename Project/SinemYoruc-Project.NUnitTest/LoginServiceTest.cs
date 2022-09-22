using Microsoft.Extensions.Options;
using NHibernate;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.NUnitTest
{
    public class LoginServiceTest
    {
        ILoginService loginService;
        ISession session;
        IOptionsMonitor<JwtConfig> jwtConfig;

        [SetUp]
        public void Setup()
        {
            loginService = new LoginService(session, jwtConfig);
        }


        [Test]
        public void Login_Test()
        {

        }
    }
}
