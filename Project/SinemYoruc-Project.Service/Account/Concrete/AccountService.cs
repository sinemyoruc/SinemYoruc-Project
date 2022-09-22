using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using NHibernate;
using Serilog;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using System;
using System.Linq;

namespace SinemYoruc_Project.Service
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Account> hibernateRepository;

        public AccountService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Account>(session);
        }
        public override BaseResponse<AccountDto> Insert(AccountDto insertResource)
        {
            try
            {
                var tempEntity = mapper.Map<AccountDto, Account>(insertResource);
                var email = hibernateRepository.Entities.Where(x => x.Email == insertResource.Email).ToList();
                if (email.Count == 0)
                {
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
                else
                {
                    Log.Error("AccountService.Insert", "Email is already exist.");
                    return new BaseResponse<AccountDto>("Email is already exist.");
                }
            }
                
            catch (Exception ex)
            {
                Log.Error("AccountService.Insert", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<AccountDto>(ex.Message);
            }
        }
    }
}
