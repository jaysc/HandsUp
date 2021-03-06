﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Mvc;
using HandsUp.Shared.Models;
using System.Threading.Tasks;

namespace HandsUp.Server.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private static UserInfo LoggedOutUser = new UserInfo { IsAuthenticated = false };

        [HttpGet("user")]
        public UserInfo GetUser()
        {
            return User.Identity.IsAuthenticated
                ? new UserInfo { Name = User.Identity.Name, IsAuthenticated = true }
                : LoggedOutUser;
        }

        [HttpGet("user/signin")]
        public async Task SignIn(string redirectUri)
        {
            if (string.IsNullOrEmpty(redirectUri) || !Url.IsLocalUrl(redirectUri))
            {
                redirectUri = "/";
            }

            await HttpContext.ChallengeAsync(
                TwitterDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = redirectUri });
        }

        [HttpGet("user/signout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/");
        }
    }
}
