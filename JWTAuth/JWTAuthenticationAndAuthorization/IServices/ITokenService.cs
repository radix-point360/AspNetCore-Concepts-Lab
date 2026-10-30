using JWTAuthenticationAndAuthorization.Entities;
using System.Security.Claims;

namespace JWTAuthenticationAndAuthorization.IServices
{
    public interface ITokenService
    {
        public string GenerateAccessToken(List<Claim> claims);
        public RefreshToken GenerateRefreshToken(string username);
    }

}
