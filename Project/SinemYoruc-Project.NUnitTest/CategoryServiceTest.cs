using AutoMapper;
using NHibernate;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Dto;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.NUnitTest
{
    public class CategoryServiceTest
    {
        ICategoryService categoryService;
        ISession session;
        IMapper mapper;
        [SetUp]
        public void Setup()
        {
            categoryService = new CategoryService(session, mapper);
        }


        [Test]
        public void Category_Insert_Test()
        {
            //Arrange
            CategoryDto category = new CategoryDto();
            category.CategoryName = "CategoryTest";
            var response = category;

            //Act
            var result = categoryService.Insert(category);

            //Assert
            Assert.Equals(response, result);
        }


        [Test]
        public void Category_GetAll_Test()
        {
            //Arrange
            CategoryDto category = new CategoryDto();
            category.CategoryName = "Test";


            //Act
            var response = categoryService.Insert(category);
            BaseResponse<IEnumerable<CategoryDto>> result = categoryService.GetAll();

            //Assert
            Assert.AreEqual(response.Success, result.Success);
        }

    
    }
}