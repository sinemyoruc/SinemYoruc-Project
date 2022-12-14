using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using Serilog;
using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SinemYoruc_Project.Service
{
    public class LoginService : ILoginService
    {

        protected readonly ISession session;
        protected readonly IHibernateRepository<Account> hibernateRepository;
        private readonly JwtConfig jwtConfig;

        public LoginService(ISession session,  IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.session = session;
            this.jwtConfig = jwtConfig.CurrentValue;
            hibernateRepository = new HibernateRepository<Account>(session);
        }


        
        public BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest)
        {
            try
            {
                if (tokenRequest is null)
                {
                    Log.Error("LoginService.GenerateToken: Please enter valid informations");
                    return new BaseResponse<TokenResponse>("Please enter valid informations.");
                }

                var account = hibernateRepository.Where(x => x.Email.Equals(tokenRequest.Email)).FirstOrDefault();
                if (account is null)
                {
                    Log.Error("LoginService.GenerateToken: Please validate your informations that you provided");
                    return new BaseResponse<TokenResponse>("Please validate your informations that you provided.");
                }

                //MD5 Hash for login password
                PasswordExtension extension = new PasswordExtension();
                var encodedPassword = extension.GetMd5Hash(tokenRequest.Password);
                tokenRequest.Password = encodedPassword;

                if (!account.Password.Equals(tokenRequest.Password))
                {
                    Log.Error("LoginService.GenerateToken: Please validate your informations that you provided");
                    return new BaseResponse<TokenResponse>("Please validate your informations that you provided.");
                }

                DateTime now = DateTime.UtcNow;
                string token = GetToken(account, now);

                try
                {
                    account.LastActivity = now;

                    hibernateRepository.BeginTransaction();
                    hibernateRepository.Update(account);
                    hibernateRepository.Commit();
                    hibernateRepository.CloseTransaction();
                }
                catch (Exception ex)
                {
                    Log.Error("GenerateToken Update Account LastActivity:", ex);
                    hibernateRepository.Rollback();
                    hibernateRepository.CloseTransaction();
                }

                TokenResponse tokenResponse = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    Email = account.Email,
                    SessionTimeInSecond = jwtConfig.AccessTokenExpiration * 60
                };

                //Send Email
                MailExtension mailExtension = new MailExtension();
                mailExtension.SendLoginMail(tokenRequest.Email);

                return new BaseResponse<TokenResponse>(tokenResponse);
            }
            catch (Exception ex)
            {
                Log.Error("GenerateToken :", ex);
                return new BaseResponse<TokenResponse>("GenerateToken Error");
            }
        }


        private string GetToken(Account account, DateTime date)
        {
            Claim[] claims = GetClaims(account);
            byte[] secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: date.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private Claim[] GetClaims(Account account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim("AccountId", account.Id.ToString())
            };

            return claims;
        }
    }
}
