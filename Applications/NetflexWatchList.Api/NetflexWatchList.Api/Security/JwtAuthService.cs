namespace NetflexWatchList.Api.Security
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
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
        private readonly string secureKey = "secure key for Netflix watchlist service";

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The token as string.
        /// </returns>
        public string GenerateToken(Guid userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtHeader = new JwtHeader(signingCredentials);

            var payload = new JwtPayload(userId.ToString(), null, null, null, DateTime.Today.AddMinutes(10));
            var securityToken = new JwtSecurityToken(jwtHeader, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
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
            var secureKey = Encoding.ASCII.GetBytes(this.secureKey);

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
