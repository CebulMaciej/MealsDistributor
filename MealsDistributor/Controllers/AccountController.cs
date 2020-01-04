using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Users.Abstract;
using Domain.Providers.Users.Request.Abstract;
using Domain.Providers.Users.Request.Concrete;
using Domain.Providers.Users.Response;
using Domain.Providers.Users.Response.Abstract;
using Domain.Repositories.Abstract;
using MealsDistributor.Model.Request.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserProvider _userProvider;

        public AccountController(ILogger logger, IUserProvider userProvider)
        {
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Login(LoginRequestModel requestModel)
        {
            try
            {
                IProvideUserRequestToLogin request = new ProvideUserRequestToLogin(requestModel.Login, requestModel.Password);
                IProvideUserResponse response = await _userProvider.GetUserByLoginAndPassword(request);

                if (response.Result != UserProvideResultEnum.Success)
                {
                    return Forbid();
                }

                ClaimsIdentity claimsIdentity = PrepareClaimsWithPropertiesToSignIn(response, out var authProperties);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        public async Task<ActionResult> LogOut()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        private static ClaimsIdentity PrepareClaimsWithPropertiesToSignIn(IProvideUserResponse response,
            out AuthenticationProperties authProperties)
        {
            IList<Claim> claims = new List<Claim>
            {
                new Claim("Id", response.User.Id.ToString()),
                new Claim("Email", response.User.Email)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);


            authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };
            return claimsIdentity;
        }

    }
}