using System.ComponentModel.DataAnnotations;

namespace PaymentJWTRefreshToken.Models.DTos.Requests
{
    public class TokenRequest
    {
        [Required]
        public string Token {get; set;}
        [Required]
        public string RefreshToken {get; set;}
    }
}