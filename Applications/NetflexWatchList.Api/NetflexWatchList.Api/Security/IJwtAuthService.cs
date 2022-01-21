namespace NetflexWatchList.Api.Security
{
    using System;
    using System.IdentityModel.Tokens.Jwt;

    /// <summary>
    /// The JwtAuthService Interface.
    /// </summary>
    public interface IJwtAuthService
    {
        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The token as string.</returns>
        string GenerateToken(Guid userId);

        /// <summary>
        /// Validates the specified JWT token.
        /// </summary>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>The JwtSecurityToken.</returns>
        JwtSecurityToken Validate(string jwtToken);
    }
}
