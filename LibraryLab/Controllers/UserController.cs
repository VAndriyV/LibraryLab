using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services.Interfaces;
using LibraryLab.TokenUtil;
using LibraryLab.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LibraryLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel userLogin)
        {
            try
            {
                var user = await _userService.LoginAsync(userLogin.Email, userLogin.Password);
                var identity = ConfigureIdentity.GetIdentity(user.Email,user.RoleId);
                var now = DateTime.UtcNow;
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: identity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    email = identity.FindFirst("email"),
                    roleId=identity.FindFirst("roleId")
                };
                
                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
                return Ok();
            }
            catch(UserNotFoundException e)
            {
                return StatusCode(400, e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationViewModel newUser)
        {
            try
            {
                var user = Mapper.Map<User>(newUser);
                await _userService.RegistrationAsync(user);
                return Ok("Welcome, "+user.Email+", now you can login");
            }
            catch(UserIsAlreadyExistException e)
            {
                return new JsonResult(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}