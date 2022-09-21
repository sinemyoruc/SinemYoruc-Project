using AutoMapper;
using NHibernate;
using Serilog;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SinemYoruc_Project.Service
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Product> hibernateRepositoryProduct;
        protected readonly IHibernateRepository<Category> hibernateRepositoryCategory;
        protected readonly IHibernateRepository<ProductsOffer> hibernateRepositoryProductsOffer;


        public ProductService(ISession session, IMapper mapper) : base (session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepositoryProduct = new HibernateRepository<Product>(session);
            hibernateRepositoryCategory = new HibernateRepository<Category>(session);
            hibernateRepositoryProductsOffer = new HibernateRepository<ProductsOffer>(session);
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
                var category = hibernateRepositoryCategory.Entities.Where(x => x.Id == insertResource.Category.Id).FirstOrDefault();
                var product = mapper.Map<ProductDto, Product>(insertResource);
                
                if (category is null)
                {
                    Log.Error("ProductService.Insert");
                    return new BaseResponse<ProductDto>("Please enter valid Category Id");
                }
                else
                {
                    hibernateRepositoryProduct.BeginTransaction();
                    hibernateRepositoryProduct.Save(product);
                    hibernateRepositoryProduct.Commit();
                    hibernateRepositoryProduct.CloseTransaction();

                    return new BaseResponse<ProductDto>(mapper.Map<Product, ProductDto>(product));
                }
              
            }
            catch (Exception ex)
            {
                Log.Error("ProductService.Insert", ex);
                hibernateRepositoryProduct.Rollback();
                hibernateRepositoryProduct.CloseTransaction();
                return new BaseResponse<ProductDto>(ex.Message);
            }
        }

        public BaseResponse<Product> ProductsOffer(ProductsOffer productsOffer)
        {
            var product = hibernateRepositoryProduct.Where(x => x.Id.Equals(productsOffer.ProductId)).FirstOrDefault(); //Retrieving the product with the desired id
            if (product != null) {  
                if (product.isOfferable == true & product.isSold == false) {
                    product.ProductsOffer = productsOffer;
                    //DB 
                    hibernateRepositoryProductsOffer.BeginTransaction();
                    hibernateRepositoryProductsOffer.Save(productsOffer);
                    hibernateRepositoryProductsOffer.Commit();
                    hibernateRepositoryProductsOffer.CloseTransaction();

                    hibernateRepositoryProduct.BeginTransaction();
                    hibernateRepositoryProduct.Update(product);
                    hibernateRepositoryProduct.Commit();
                    hibernateRepositoryProduct.CloseTransaction();

                    return new BaseResponse<Product>(product);
                }
                else
                {
                    return new BaseResponse<Product>("No offers can be made for this product.");
                }
            }
            else
            {
                return new BaseResponse<Product>("Product is not found");
            }
        }

        public BaseResponse<Product> SoldProducts(int id)
        {
            //isSold and isOfferable fields are updated when the product is sold

            var product = hibernateRepository.Where(x => x.Id == id).FirstOrDefault(); //Retrieving the product with the desired id
            if(product is null)
            {
                return new BaseResponse<Product>("Product is not found");
            }
            else
            {
                product.isSold = true;
                product.isOfferable = false;

                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(product);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();

                return new BaseResponse<Product>(product);
            }
            
        }

     }
}
