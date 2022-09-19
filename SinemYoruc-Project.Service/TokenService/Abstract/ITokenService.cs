using SinemYoruc_Project.Base;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;

namespace SinemYoruc_Project.Service
{
    public interface ITokenService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}
