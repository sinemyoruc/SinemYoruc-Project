using SinemYoruc_Project.Base;

namespace SinemYoruc_Project.Service
{
    public interface ILoginService
    {
        public BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}
