using AutoMapper;
using NHibernate;
using Serilog;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using System;
using System.Collections.Generic;

namespace SinemYoruc_Project.Service
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Product> hibernateRepositoryProduct;
        protected readonly IHibernateRepository<Category> hibernateRepositoryCategory;
        protected readonly IProductService service;


        public ProductService(ISession session, IMapper mapper) : base (session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepositoryProduct = new HibernateRepository<Product>(session);
            hibernateRepositoryCategory = new HibernateRepository<Category>(session);
        }

        public virtual BaseResponse<IEnumerable<ProductDto>> GetAll()
        {
            try
            {
                var tempEntity = hibernateRepositoryProduct.GetAll();
                var result = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(tempEntity);
                return new BaseResponse<IEnumerable<ProductDto>>(result);
            }
            catch (Exception ex)
            {
                Log.Error("ProductService.GetAll", ex);
                return new BaseResponse<IEnumerable<ProductDto>>(ex.Message);
            }
        }

        public BaseResponse<ProductDto> Insert(ProductDto insertResource)
        {
            try
            {
                var product = mapper.Map<ProductDto, Product>(insertResource);
                var category = product.Category;
                product.Category = null;
                hibernateRepositoryProduct.BeginTransaction();
                hibernateRepositoryProduct.Save(product);
                hibernateRepositoryProduct.Commit();
                hibernateRepositoryProduct.CloseTransaction();

                hibernateRepositoryCategory.BeginTransaction();
                hibernateRepositoryCategory.Save(category);
                hibernateRepositoryCategory.Commit();
                hibernateRepositoryCategory.CloseTransaction();

                return new BaseResponse<ProductDto>(mapper.Map<Product, ProductDto>(product));
            }
            catch (Exception ex)
            {
                Log.Error("ProductService.Insert", ex);
                hibernateRepositoryProduct.Rollback();
                hibernateRepositoryProduct.CloseTransaction();
                return new BaseResponse<ProductDto>(ex.Message);
            }
        }

    }
}
