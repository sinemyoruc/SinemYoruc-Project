using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
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
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Account> hibernateRepository;
        protected readonly IHibernateRepository<Product> hibernateRepositoryProduct;
        protected readonly IHibernateRepository<ProductsOffer> hibernateRepositoryProductsOffer;

        public AccountService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Account>(session);
            hibernateRepositoryProduct = new HibernateRepository<Product>(session);
            hibernateRepositoryProductsOffer = new HibernateRepository<ProductsOffer>(session);
        }
        public override BaseResponse<AccountDto> Insert(AccountDto insertResource)
        {
            try
            {
                var tempEntity = mapper.Map<AccountDto, Account>(insertResource);

                try
                {
                    //Validation Check
                    AccountValidator validations = new AccountValidator();
                    ValidationResult result = validations.Validate(tempEntity);
                    validations.ValidateAndThrow(tempEntity);
                }
                catch (Exception ex)
                {
                    Log.Error("AccountService.Insert", ex);
                    return new BaseResponse<AccountDto>(ex.Message);
                }


                //MD5 HASH FOR PASSWORD
                PasswordExtension extension = new PasswordExtension();
                var encodedPassword = extension.GetMd5Hash(tempEntity.Password);
                tempEntity.Password = encodedPassword;

                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(tempEntity);
                hibernateRepository.Commit();

                hibernateRepository.CloseTransaction();

                //Send Email
                MailExtension mailExtension = new MailExtension();
                mailExtension.SendWelcomeMail(insertResource.Email);

                return new BaseResponse<AccountDto>(mapper.Map<Account, AccountDto>(tempEntity));
            }
            catch (Exception ex)
            {
                Log.Error("AccountService.Insert", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<AccountDto>(ex.Message);
            }
        }


        public BaseResponse<IEnumerable<Product>> GetProduct(int id) //The method that lists the user's products 
        {
            try
            {
                var product = hibernateRepositoryProduct.Entities.Where(x => x.AccountId == id);
                return new BaseResponse<IEnumerable<Product>>(product);
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
                var product = hibernateRepositoryProductsOffer.Entities.Where(x => x.OfferAccountId == id);
                return new BaseResponse<IEnumerable<ProductsOffer>>(product);
            }
            catch (Exception ex)
            {
                Log.Error("AccountService.GetOfferProduct", ex);
                return new BaseResponse<IEnumerable<ProductsOffer>>(ex.Message);
            }
        }


        public BaseResponse<Product> RecievedOffer(int id) //The method that lists the offers user received
        {
            try
            {
                var product = hibernateRepositoryProduct.Entities.Where(c => c.AccountId == id).FirstOrDefault();
                var productOffer = hibernateRepositoryProductsOffer.Entities.Where(x => x.ProductId == product.Id).ToList();
                if(productOffer.Count > 0)
                {
                    return new BaseResponse<Product>(product);
                }
                else
                {
                    return new BaseResponse<Product>("You don't have any products that received an offer.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("AccountService.RecievedOffer", ex);
                return new BaseResponse<Product>(ex.Message);
            }
        }

        public BaseResponse<Product> AcceptOffer(int id) //The method accepts an offer with a id
        {
            try
            {
                var result = hibernateRepositoryProduct.Entities.Where(x => x.ProductsOffer.Id == id).FirstOrDefault();
                if (result != null)
                {
                    result.isOfferable = false;
                    result.isSold = true;
                    result.ProductsOffer.OfferStatus = true;

                    //Send Email
                    MailExtension mailExtension = new MailExtension();
                    mailExtension.SendAcceptOfferMail();

                    mapper.Map<Product, ProductDto>(result);
                    return new BaseResponse<Product>(result);
                }
                else
                {
                    return new BaseResponse<Product>("Offer is not found");
                }
            }
            catch (Exception ex)
            {
                Log.Error("AccountService.AcceptOffer", ex);
                return new BaseResponse<Product>(ex.Message);
            }
           
        }

        public BaseResponse<Product> RefuseOffer(int id) //The method refuses an offer with a id
        {
            try
            {
                var result = hibernateRepositoryProduct.Entities.Where(x => x.ProductsOffer.Id == id).FirstOrDefault();
                var offer = hibernateRepositoryProductsOffer.Entities.Where(x => x.Id == id).FirstOrDefault();
                if(result != null)
                {
                    result.isOfferable = true;
                    result.isSold = false;
                    result.ProductsOffer.OfferStatus = false;
                    offer.OfferStatus = false;
                    mapper.Map<Product, ProductDto>(result);
                    mapper.Map<ProductsOffer, ProductsOfferDto>(offer);

                    //Send Email
                    MailExtension mailExtension = new MailExtension();
                    mailExtension.SendRefuseOfferMail();
                    
                    return new BaseResponse<Product>(result);
                }
                else
                {
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
