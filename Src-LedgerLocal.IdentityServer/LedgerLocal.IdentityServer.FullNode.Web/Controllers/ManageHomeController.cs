using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.ViewModels;
using IdentityServer4.Models;
using IdentityServer4.Configuration;
using IdentityServer4.Services;
using IdentityServer4;
using IdentityServer4.Validation;
using LedgerLocal.IdentityServer.FullNode.Web;
using IdentityModel.Client;
using System.ComponentModel.DataAnnotations;
using IdentityServer4.EntityFramework.Entities;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Authorize]
    public class ManageHomeController : Controller
    {
        private UserManager<User> userManager;
        private ITokenService _ts;
        private IUserClaimsPrincipalFactory<User> _principalFactory;
        private IdentityServerOptions _option;

        private Task<User> CurrentUser =>
            userManager.FindByNameAsync(HttpContext.User.Identity.Name);

        public ManageHomeController(UserManager<User> userMgr,
            ITokenService ts,
            IUserClaimsPrincipalFactory<User> principalFactory,
            IdentityServerOptions option)
        {
            userManager = userMgr;
            _ts = ts;
            _principalFactory = principalFactory;
            _option = option;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(GetAuthInfo(nameof(Index), nameof(ManageHomeController)));
        }

        private Dictionary<string, object> GetAuthInfo(string actionName, string controllerName)
        {
            return new Dictionary<string, object>
            {
                // ["Controller"] = controllerName,
                // ["Action"] = actionName,
                ["User"] = HttpContext.User?.Identity.Name,
                ["Authenticated"] = HttpContext.User?.Identity.IsAuthenticated,
                ["Authentication Type"] = HttpContext.User?.Identity.AuthenticationType,
                ["In SuperAdmins Role"] = HttpContext.User?.IsInRole("SuperAdmins"),
                ["In Staff Role"] = HttpContext.User?.IsInRole("Staff"),
                ["In Customers Role"] = HttpContext.User?.IsInRole("Customers")
            };
        }

        public async Task<IActionResult> SetUserCustomProps()
        {
            return View(await CurrentUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GetToken(string audience)
        {
            var Request = new TokenCreationRequest();
            var User = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var IdentityPricipal = await _principalFactory.CreateAsync(User);
            
            var IdServerPrincipal = IdentityServerPrincipal.Create(User.Id.ToString(), User.UserName, IdentityPricipal.Claims.ToArray());

            var lstScope = new List<Scope>
            {
                new Scope
                {
                    Name = "api.main",
                    Emphasize = true,
                    UserClaims = new List<string>
                    {
                        "role",
                        "name"
                    }
                },
                new Scope
                {
                    Name = "api.blockchain",
                    Emphasize = true,
                    UserClaims = new List<string>
                    {
                        "role",
                        "name"
                    }
                }
            };

            var c1 = new IdentityServer4.Models.Client
            {
                ClientId = "generatedTokenClient",
                ClientName = "generatedTokenClient",
                Enabled = true,
                AccessTokenType = AccessTokenType.Jwt,
                ClientSecrets = new List<IdentityServer4.Models.Secret>
                {
                    new IdentityServer4.Models.Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                }
            };

            Request.Subject = IdServerPrincipal;
            Request.IncludeAllIdentityClaims = true;
            Request.ValidatedRequest = new ValidatedRequest();
            Request.ValidatedRequest.Subject = Request.Subject;
            Request.ValidatedRequest.SetClient(c1);

            Request.Resources = new Resources(Config.GetIdentityResources(), Config.GetApiResources());
            Request.ValidatedRequest.Options = _option;
            Request.ValidatedRequest.ClientClaims = IdentityPricipal.Claims.ToArray();

            var Token = await _ts.CreateAccessTokenAsync(Request);
            Token.Issuer = "https://" + HttpContext.Request.Host.Value;
            Token.Audiences = new List<string> { audience };

            if (Token.Claims == null)
            {
                Token.Claims = new List<Claim>();
            }

            var rolesClaim = IdentityPricipal.FindAll("role");

            if (rolesClaim != null && rolesClaim.Count() > 0)
            {
                foreach(var r1 in rolesClaim)
                {
                    Token.Claims.Add(r1);
                }
            }

            var nameClaim = IdentityPricipal.FindFirst("name");

            if (nameClaim != null)
            {
                Token.Claims.Add(nameClaim);
            }

            var custIdClaim = IdentityPricipal.FindFirst("customerid");

            if (custIdClaim != null)
            {
                Token.Claims.Add(custIdClaim);
            }

            var TokenValue = await _ts.CreateSecurityTokenAsync(Token);
            return Ok(TokenValue);
        }

        [Authorize]
        public IActionResult Block()
        {
            return View();
        }
    }
}
