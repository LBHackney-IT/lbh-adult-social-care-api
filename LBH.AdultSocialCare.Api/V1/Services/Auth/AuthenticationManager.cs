using Common.Exceptions.CustomExceptions;
using Common.Exceptions.Models;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.UserBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
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

namespace LBH.AdultSocialCare.Api.V1.Services.Auth
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<Role> _roleManager;

        private User _user;

        public AuthenticationManager(UserManager<User> userManager, IConfiguration configuration, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<bool> ValidateUser(string userName, string password = null)
        {
            _user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
            if (_user != null && _user.PasswordHash == null) return true;
            return (_user != null && await _userManager.CheckPasswordAsync(_user, password).ConfigureAwait(false));
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims().ConfigureAwait(false);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public HackneyTokenRequest ValidateHackneyJwtToken(string hackneyToken)
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
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken) validatedToken;

                var hackneyAuthRequest = new HackneyTokenRequest
                {
                    Sub = jwtToken.Claims.First(x => x.Type == "sub").Value,
                    Email = jwtToken.Claims.First(x => x.Type == "email").Value,
                    Iss = jwtToken.Claims.First(x => x.Type == "iss").Value,
                    Name = jwtToken.Claims.First(x => x.Type == "name").Value,
                    Groups = jwtToken.Claims.Where(x => x.Type == "groups").Select(x => x.Value).ToList(),
                    Iat = int.Parse(jwtToken.Claims.First(x => x.Type == "iat").Value)
                };

                switch (Debugger.IsAttached)
                {
                    // Check if id token is expired in production
                    case false:
                        {
                            var timeIssued = DateTimeOffset.FromUnixTimeSeconds(hackneyAuthRequest.Iat);

                            // If not hackney email, fail
                            if (!hackneyAuthRequest.Email.Contains("@hackney.gov.uk"))
                            {
                                throw new Exception("Invalid token");
                            }

                            // By default the token expires in one week. If more or less then reject token
                            if ((timeIssued.AddDays(7).AddMinutes(10) < DateTimeOffset.Now) || (timeIssued.AddDays(7) > DateTimeOffset.Now.AddDays(7).AddMinutes(10)))
                            {
                                throw new Exception("Invalid token");
                            }

                            break;
                        }
                }

                return hackneyAuthRequest;
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                {
                    Console.WriteLine(e);
                }
                throw new ApiException("Invalid token. Please check and try again", StatusCodes.Status401Unauthorized);
            }
        }

        public async Task<UsersDomain> GetOrCreateUser(HackneyTokenRequest hackneyTokenRequest)
        {
            var user = await _userManager.FindByEmailAsync(hackneyTokenRequest.Email).ConfigureAwait(false);
            switch (user)
            {
                case null:
                    {
                        var userEntity = new User
                        {
                            Email = hackneyTokenRequest.Email,
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = hackneyTokenRequest.Email.ToUpperInvariant(),
                            NormalizedUserName = hackneyTokenRequest.Email.ToUpperInvariant(),
                            PasswordHash = null,
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = hackneyTokenRequest.Email,
                            Name = hackneyTokenRequest.Name
                        };

                        var result = await _userManager.CreateAsync(userEntity).ConfigureAwait(false);

                        if (result.Succeeded)
                        {
                            var defaultRoles = new List<string> {RolesEnum.User.GetDisplayName()};
                            var newUserRoles = new List<string>();
                            foreach (var userRole in defaultRoles)
                            {
                                if (await _roleManager.RoleExistsAsync(userRole).ConfigureAwait(false))
                                {
                                    newUserRoles.Add(userRole);
                                }
                            }

                            if (newUserRoles.Count > 0)
                            {
                                await _userManager.AddToRolesAsync(userEntity, newUserRoles).ConfigureAwait(false);
                            }

                            return userEntity?.ToDomain();
                        }

                        var validationErrorCollection = new ValidationErrorCollection();

                        foreach (var error in result.Errors)
                        {
                            validationErrorCollection.Add(new ValidationError
                            {
                                Message = error.Description,
                                ControlID = error.Code,
                                ID = error.Code
                            });
                        }

                        throw new ApiException($"User creation failed", (int) StatusCodes.Status400BadRequest,
                            validationErrorCollection);
                    }
            }

            return user.ToDomain();
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
