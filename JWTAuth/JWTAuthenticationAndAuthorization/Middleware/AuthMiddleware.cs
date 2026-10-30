using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;

namespace JWTAuthenticationAndAuthorization.Middleware
{
    public static class AuthMiddleware
    {
        public static IServiceCollection ConfigureJWTAuthentication(this IServiceCollection servics, IConfiguration configuration)
        {

            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = configuration["Jwt:Key"];

            servics.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "JwtBearer";

            }).AddJwtBearer("JwtBearer", option =>
            {
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = issuer,
                    ValidAudience = "audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!))
                };
            });

            return servics;
        }


        public static IServiceCollection ConfigureJWTAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            
            return services;
        }

    }
}
