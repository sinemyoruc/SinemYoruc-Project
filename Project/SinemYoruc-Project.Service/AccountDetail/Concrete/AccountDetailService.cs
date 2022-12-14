using AutoMapper;
using NHibernate;
using Serilog;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SinemYoruc_Project
{
    public class AccountDetailService : IAccountDetailService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Product> hibernateRepositoryProduct;
        protected readonly IHibernateRepository<ProductsOffer> hibernateRepositoryProductsOffer;
        
        public AccountDetailService(ISession session, IMapper mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepositoryProduct = new HibernateRepository<Product>(session);
            hibernateRepositoryProductsOffer = new HibernateRepository<ProductsOffer>(session);
        }

        public BaseResponse<IEnumerable<Product>> GetProduct(int id) //The method that lists the user's products 
        {
            try
            {
                var product = hibernateRepositoryProduct.Entities.Where(x => x.AccountId == id).ToList();
                if(product.Count == 0)
                {
                    Log.Error("AccountService.GetProduct: Product is not found");
                    return new BaseResponse<IEnumerable<Product>>("Product is not found");
                }
                else
                {
                    return new BaseResponse<IEnumerable<Product>>(product);
                }
                
            }
            catch (Exception ex)
            {
                Log.Error("AccountService.GetProduct", ex);
                return new BaseResponse<IEnumerable<Product>>(ex.Message);
            }
        }

        public BaseResponse<IEnumerable<ProductsOffer>> GetOfferProduct(int id) //The method that lists the offers user made
        {
            try
            {
                var product = hibernateRepositoryProductsOffer.Entities.Where(x => x.OfferAccountId == id).ToList();
                if(product.Count == 0)
                {
                    Log.Error("AccountService.GetOfferProduct: Product is not found");
                    return new BaseResponse<IEnumerable<ProductsOffer>>("Product is not found");
                }
                else
                {
                    return new BaseResponse<IEnumerable<ProductsOffer>>(product);
                }
                
            }
            catch (Exception ex)
            {
                Log.Error("AccountService.GetOfferProduct", ex);
                return new BaseResponse<IEnumerable<ProductsOffer>>(ex.Message);
            }
        }


        public BaseResponse<IEnumerable<Product>> GetRecievedOffer(int id) //The method that lists the offers user received
        {
            try
            {
                var product = hibernateRepositoryProduct.Entities.Where(c => c.AccountId == id).Where(x => x.ProductsOffer != null).ToList();
                if (product.Count != 0)
                {
                    return new BaseResponse<IEnumerable<Product>>(product);
                }
                else
                {
                    Log.Error("AccountService.RecievedOffer: You don't have any products that received an offer.");
                    return new BaseResponse<IEnumerable<Product>>("You don't have any products that received an offer.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("AccountService.RecievedOffer", ex);
                return new BaseResponse<IEnumerable<Product>>(ex.Message);
            }
        }

        public BaseResponse<Product> CreateAcceptOffer(int id) //The method accepts an offer with a id
        {
            try
            {
                var result = hibernateRepositoryProduct.Entities.Where(x => x.ProductsOffer.Id == id).FirstOrDefault();
                var offer = hibernateRepositoryProductsOffer.Entities.Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    if(result.isSold == false)
                    {
                        result.isOfferable = false;
                        result.ProductsOffer.OfferStatus = true;
                        offer.OfferStatus = true;
                        result.Price = offer.Offer;

                        hibernateRepositoryProductsOffer.BeginTransaction();
                        hibernateRepositoryProductsOffer.Update(offer);
                        hibernateRepositoryProductsOffer.Commit();
                        hibernateRepositoryProductsOffer.CloseTransaction();

                        //Send Email
                        MailExtension mailExtension = new MailExtension();
                        mailExtension.SendAcceptOfferMail();

                        return new BaseResponse<Product>(result);
                    }
                    else
                    {
                        Log.Error("AccountService.AcceptOffer: Product is already sold");
                        return new BaseResponse<Product>("Product is already sold.");
                    }
                    
                }
                else
                {
                    Log.Error("AccountService.AcceptOffer: Offer is not found");
                    return new BaseResponse<Product>("Offer is not found.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("AccountService.AcceptOffer", ex);
                return new BaseResponse<Product>(ex.Message);
            }

        }

        public BaseResponse<Product> CreateRefuseOffer(int id) //The method refuses an offer with a id
        {
            try
            {
                var result = hibernateRepositoryProduct.Entities.Where(x => x.ProductsOffer.Id == id).FirstOrDefault();
                var offer = hibernateRepositoryProductsOffer.Entities.Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    if (result.isSold == false)
                    {
                        result.isOfferable = true;
                        result.ProductsOffer.OfferStatus = false;
                        offer.OfferStatus = false;

                        hibernateRepositoryProductsOffer.BeginTransaction();
                        hibernateRepositoryProductsOffer.Update(offer);
                        hibernateRepositoryProductsOffer.Commit();
                        hibernateRepositoryProductsOffer.CloseTransaction();

                        //Send Email
                        MailExtension mailExtension = new MailExtension();
                        mailExtension.SendRefuseOfferMail();

                        return new BaseResponse<Product>(result);
                    }
                    else
                    {
                        Log.Error("AccountService.RefuseOffer: Product is already sold");
                        return new BaseResponse<Product>("Product is already sold.");
                    }
                }
                else
                {
                    Log.Error("AccountService.RefuseOffer: Offer is not found");
                    return new BaseResponse<Product>("Offer is not found.");
                }
            }
            catch (Exception ex)
            {

                Log.Error("AccountService.RefuseOffer", ex);
                return new BaseResponse<Product>(ex.Message);
            }

        }
    }
}
