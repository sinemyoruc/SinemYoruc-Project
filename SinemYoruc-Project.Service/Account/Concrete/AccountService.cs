using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using NHibernate;
using Serilog;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;
using System;

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

                /* Ayni şifrelerin hashleri aynı olmasın diye tuzlama yapılabilir
                byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                password: tempEntity.Password!,
                                salt: salt,
                                prf: KeyDerivationPrf.HMACSHA256,
                                iterationCount: 100000,
                                numBytesRequested: 256 / 8));

                tempEntity.Password = hashed;
                */
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
    }
}
