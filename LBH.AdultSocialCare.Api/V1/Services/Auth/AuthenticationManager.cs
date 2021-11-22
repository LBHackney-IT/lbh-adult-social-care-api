using Common.Exceptions.CustomExceptions;
using Common.Exceptions.Models;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
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
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;

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

        public User GetUser()
        {
            return _user;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims().ConfigureAwait(false);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public HackneyTokenDomain ValidateHackneyJwtToken(string hackneyToken)
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

                var hackneyAuthDomain = new HackneyTokenDomain
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
                            var timeIssued = DateTimeOffset.FromUnixTimeSeconds(hackneyAuthDomain.Iat);

                            // If not hackney email, fail
                            if (!hackneyAuthDomain.Email.Contains("@hackney.gov.uk"))
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

                return hackneyAuthDomain;
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

        public HackneyTokenDomain ValidateHackneyJwtToken(HackneyTokenDomain hackneyTokenDomain)
        {
            try
            {
                var timeIssued = DateTimeOffset.FromUnixTimeSeconds(hackneyTokenDomain.Iat);

                // If not hackney email, fail
                if (!hackneyTokenDomain.Email.Contains("@hackney.gov.uk"))
                {
                    throw new Exception("Invalid token");
                }

                // By default the token expires in one week. If more or less then reject token
                if ((timeIssued.AddDays(7).AddMinutes(10) < DateTimeOffset.Now) || (timeIssued.AddDays(7) > DateTimeOffset.Now.AddDays(7).AddMinutes(10)))
                {
                    throw new Exception("Invalid token");
                }

                return hackneyTokenDomain;
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

        public async Task<AppUserDomain> GetOrCreateUser(HackneyTokenDomain hackneyTokenDomain)
        {
            var user = await _userManager.FindByEmailAsync(hackneyTokenDomain.Email).ConfigureAwait(false);
            switch (user)
            {
                case null:
                    {
                        var userEntity = new User
                        {
                            Email = hackneyTokenDomain.Email,
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = hackneyTokenDomain.Email.ToUpperInvariant(),
                            NormalizedUserName = hackneyTokenDomain.Email.ToUpperInvariant(),
                            PasswordHash = null,
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = hackneyTokenDomain.Email,
                            Name = hackneyTokenDomain.Name
                        };

                        var result = await _userManager.CreateAsync(userEntity).ConfigureAwait(false);

                        if (result.Succeeded)
                        {
                            var defaultRoles = new List<string> { RolesEnum.Broker.GetDisplayName() };
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

        public async Task<bool> AssignRolesToUser(Guid userId, IEnumerable<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString()).ConfigureAwait(false);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with Id {userId} not found");
            }

            var newUserRoles = new List<string>();
            foreach (var userRole in roles)
            {
                if (await _roleManager.RoleExistsAsync(userRole).ConfigureAwait(false))
                {
                    newUserRoles.Add(userRole);
                }
            }

            if (newUserRoles.Count > 0)
            {
                await _userManager.AddToRolesAsync(user, newUserRoles).ConfigureAwait(false);
            }

            return true;
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
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.GivenName, _user.Name),
                new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString())

            };
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
