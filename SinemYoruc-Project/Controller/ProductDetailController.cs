using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.Controller
{
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductDetailController()
        {
            
        }


    }
}
