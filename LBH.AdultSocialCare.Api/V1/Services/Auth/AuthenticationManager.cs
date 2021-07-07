using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Services.Auth
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User _user;

        public AuthenticationManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateUser(string userName, string password)
        {
            _user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, password).ConfigureAwait(false));
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims().ConfigureAwait(false);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public bool ValidateHackneyJwtToken(string hackneyToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(hackneyToken, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = false,
                    ValidateAudience = false,
                    ValidIssuer = "Hackney",
                    IssuerSigningKey = null,
                    ValidateLifetime = false,
                    SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                    {
                        var jwt = new JwtSecurityToken(token);

                        return jwt;
                    },
                    // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = Debugger.IsAttached ? TimeSpan.Zero : TimeSpan.FromMinutes(10)
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken) validatedToken;

                /*// Select and return claim if you want
                var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                return accountId;*/
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApiException("Invalid token. Please check and try again", StatusCodes.Status401Unauthorized);
            }
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSettings:securityKey"));
            // var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, _user.UserName) };
            var roles = await _userManager.GetRolesAsync(_user).ConfigureAwait(false);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value, claims: claims,
                expires: DateTime.Now.AddSeconds(Convert.ToDouble(jwtSettings.GetSection("expiryInSeconds").Value)),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
    }
}
