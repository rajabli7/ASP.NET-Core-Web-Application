using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using PhotoAndVideoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAndVideoServices.Extensions
{
    public static class HttpContextExtensions
    {
        public static CurrentUser GetCurrentUserFromCookie(this HttpContext context)
        {
            CurrentUser currentUser = new CurrentUser();
            string id;

            if (context.Request.Cookies.TryGetValue("CurrentUserId", out id))
            {
                currentUser.UserId = Convert.ToInt32(id);
            }

            if (context.Request.Cookies.TryGetValue("CurrentUserRoleId", out id))
            {
                currentUser.RoleId = Convert.ToInt32(id);
            }

            return currentUser;
        }

        public static int SetCurrentUserIdToCookie(this HttpContext context, int userId, int roleId)
        {
            context.Response.Cookies.Append("CurrentUserId", userId.ToString());
            context.Response.Cookies.Append("CurrentUserRoleId", roleId.ToString());

            return userId;
        }

    }
}
