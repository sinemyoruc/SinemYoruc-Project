using SinemYoruc_Project.Dto;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        ICategoryService categoryService;


        [Test]
        public void Category_GetAll_Test()
        {
            //Arrange
            CategoryDto category = new CategoryDto();
            category.CategoryName = "CategoryTest";
            var response = category;

            //Act
            var result = categoryService.GetAll();

            //Assert
            Assert.Equals(response, result);
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
    }
}