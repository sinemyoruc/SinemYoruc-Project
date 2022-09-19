using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : BaseController<CategoryDto, Category>
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;


        public CategoryController(ICategoryService categoryService, IMapper mapper) : base(categoryService, mapper)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }
    }
}
