using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using SinemYoruc_Project.Service;
using System;

namespace SinemYoruc_Project.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController<ProductDto, Product>
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public ProductController(IProductService productService, IMapper mapper) : base(productService, mapper)
        {
            this.mapper = mapper;
            this.productService = productService;
        }
    }
}
