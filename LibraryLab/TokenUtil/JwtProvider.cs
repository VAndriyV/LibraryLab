using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryLab.TokenUtil
{
    public class JwtProvider
    {
        public string GetEncodedJwt(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        public TokenData DecodeJwt(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            var email = jsonToken.Claims.FirstOrDefault(c => c.Type == "email").Value;
            var roleId = jsonToken.Claims.FirstOrDefault(c => c.Type == "roleId").Value;

            if (email != null && roleId != null)
            {
                return new TokenData
                {
                    Email = email,
                    RoleId = long.Parse(roleId)
                };
            }
            else
            {
                return null;
            }
        }      
                
    }
}

