namespace NetflexWatchList.Api.Security
{
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using NetflexWatchList.Shared;
    using NetflexWatchList.Shared.OptionModels;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    /// <summary>
    /// The JqtAuthService implementation.
    /// </summary>
    /// <seealso cref="NetflexWatchList.Api.Security.IJwtAuthService" />
    public class JwtAuthService : IJwtAuthService
    {
        /// <summary>
        /// The secure key.
        /// </summary>
        private readonly JwtOption _option;

        public JwtAuthService(IOptions<JwtOption> option)
        {
            _option = option.Value;
        }

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The token as string.
        /// </returns>
        public string GenerateToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.JwtSecret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(type: ClaimTypes.Name, value: userId.ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = signingCredentials,
                Issuer = AppConstants.Issuer,
                Audience = AppConstants.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Validates the specified JWT token.
        /// </summary>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>
        /// The JwtSecurityToken.
        /// </returns>
        public JwtSecurityToken Validate(string jwtToken)
        {
            var securityTokenHandler = new JwtSecurityTokenHandler();
            var secureKey = Encoding.ASCII.GetBytes(_option.JwtSecret);

            securityTokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(secureKey),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}
