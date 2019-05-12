using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryLab.TokenUtil
{
    public class ConfigureIdentity
    {
        public static ClaimsIdentity GetIdentity(string email, long roleId)
        {
            var claims = new List<Claim>
            {
                    new Claim("email", email),
                    new Claim("roleId",roleId.ToString())
            };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
