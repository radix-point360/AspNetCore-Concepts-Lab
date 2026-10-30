using System.ComponentModel.DataAnnotations;

namespace JWTAuthenticationAndAuthorization.Entities
{
    public class RefreshToken
    {
        [Key]
        public int id { get; set; } = new Guid().GetHashCode();

        public string? Username { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime? CreatedAt { get; set; }

        public bool IsExpired => ExpiresAt.HasValue && DateTime.UtcNow >= ExpiresAt.Value;

    }
}
