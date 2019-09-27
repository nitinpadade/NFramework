using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NFramework.BL.Contacts;
using NFramework.DTO.Parameters.RefreshLogin;
using NFramework.DTO.Parameters.UserLogin;
using NFramework.DTO.QueryModels.UserLogin;
using NFramework.DTO.Result.Query;

namespace NFramework.AS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IQueryExecutor _query;
        readonly ICommandHandler _command;
        public AuthController(IQueryExecutor query, ICommandHandler command)
        {
            _query = query;
            _command = command;
        }

        // GET api/values  
        [HttpPost, Route("login")]
        [EnableCors("Cors")]
        public IActionResult Login([FromBody]UserLoginParameter userLoginParams)
        {
            if (userLoginParams == null)
            {
                return BadRequest("Invalid request");
            }

            var result = _query.Execute<QueryResult<UserLoginModel>, UserLoginParameter>(userLoginParams).Data;

            if (result != null && result.IsAuthenticated)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44386/",
                    audience: "https://localhost:44343/",
                    claims: new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, result.Name),
                         new Claim("UserInfo", result.UserId.ToString() + '|' + result.Name + '|' + result.RoleId.ToString())
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new TokenDetails
                {
                    Token = tokenString,
                    RoleId = result.RoleId.GetValueOrDefault(),
                    User = result.Name,
                    UserId = result.UserId,
                    IsAuthenticated = true
                });
            }
            else
            {
                //return Unauthorized();
                return Ok(null);
            }
        }

        [HttpPost, Route("refresh")]
        [EnableCors("Cors")]
        public IActionResult Login([FromBody]RefreshLoginParameter refreshLoginParams)
        {
            

            var result = _query.Execute<QueryResult<UserLoginModel>, RefreshLoginParameter>(refreshLoginParams).Data;

            if (result != null && result.IsAuthenticated)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44386/",
                    audience: "https://localhost:44343/",
                    claims: new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, result.Name),
                         new Claim("UserInfo", result.UserId.ToString() + '|' + result.Name + '|' + result.RoleId.ToString())
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new TokenDetails
                {
                    Token = tokenString,
                    RoleId = result.RoleId.GetValueOrDefault(),
                    User = result.Name,
                    UserId = result.UserId,
                    IsAuthenticated = true
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}