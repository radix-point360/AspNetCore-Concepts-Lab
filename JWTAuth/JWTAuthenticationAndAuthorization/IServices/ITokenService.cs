using JWTAuthenticationAndAuthorization.Entities;
using System.Security.Claims;

namespace JWTAuthenticationAndAuthorization.IServices
{
    public interface ITokenService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims);
        public RefreshToken GenerateRefreshToken(string username);
        ClaimsPrincipal? GetClaimsPrincipalFromExpiredToken(string token);
    }

}
