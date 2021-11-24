using APIEventSchedules.Middlewares.Autentication;
using APIEventSchedules.Model;
using EventSchedules.Service.Contract;
using EventSchedules.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIEventSchedules.Controllers
{
   // [Authorize]
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticateService _serviceAuth;
        private AuthOptions _authOptions;

        public AuthenticateController(IUserService serviceUser, IAuthenticateService serviceAuth
            , IConfiguration config)
        {         
            _serviceAuth = serviceAuth;
            _authOptions = config.GetSection("AuthOptions").Get<AuthOptions>();
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Authenticate(UserLoginDto dto)
        {
            try
            {
                var user = _serviceAuth.Authenticate(dto);
                var response = GiveJWTToken(user.Id, "user");

                return Ok(response);
            }
            catch (Exception ee)
            {
                return BadRequest(ee.Message);
            }
        }

        private JwtTokenModel GiveJWTToken(int UserId, string role)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: now,

                    claims: GetClaims(role),
                    expires: now.Add(TimeSpan.FromMinutes(_authOptions.LifeTime)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(_authOptions.SecretKey), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new JwtTokenModel
            {
                access_token = encodedJwt,
                UserId = UserId,
            };

            return response;
        }

        private IEnumerable<Claim> GetClaims(string role)
        {
            return new[]
            {
                new Claim("role", role)
            };
        }
    }
}
