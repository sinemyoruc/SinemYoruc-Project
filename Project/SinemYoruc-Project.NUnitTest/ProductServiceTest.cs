using AutoMapper;
using NHibernate;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.NUnitTest
{
    public class ProductServiceTest
    {
        IProductService productService;
        ISession session;
        IMapper mapper;

        [SetUp]
        public void Setup()
        {
            productService = new ProductService(session, mapper);
        }


        [Test]
        public void ProductService_Test()
        {

        }
    }
}
