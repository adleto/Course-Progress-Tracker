﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCourse.WebAPI.Helpers
{
    public static class UserResolver
    {
        public static int GetUserId(ClaimsPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;
            return int.Parse(identity.FindFirst("UserId").Value);
        }
        public static List<string> GetUserRoles(ClaimsPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .ToList();
            var rolesAsString = new List<string>();
            roles.ForEach(r =>
            {
                rolesAsString.Add(r.Value);
            });
            return rolesAsString;
        }
    }
}