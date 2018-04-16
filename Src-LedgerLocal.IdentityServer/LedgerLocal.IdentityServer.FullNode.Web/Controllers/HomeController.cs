// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel.Client;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using LedgerLocal.IdentityServer.FullNode.Web;
using LedgerLocal.IdentityServer.FullNode.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManagement.Models;

namespace IdentityServer4.Quickstart.UI
{
    [SecurityHeaders]
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;


        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private ITokenService _ts;
        private IUserClaimsPrincipalFactory<User> _principalFactory;
        private IdentityServerOptions _option;

        public HomeController(IIdentityServerInteractionService interaction,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory,
            ITokenService ts,
            IUserClaimsPrincipalFactory<User> principalFactory,
            IdentityServerOptions option)
        {
            _interaction = interaction;

            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _ts = ts;
            _principalFactory = principalFactory;
            _option = option;
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }

            return View("Error", vm);
        }

        public async Task<string> GetToken(string user, string password, string audience)
        {
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync("/");

            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(user, password, audience);

            if (tokenResponse.IsError)
            {
                return tokenResponse.ErrorDescription;
            }

            return tokenResponse != null && !string.IsNullOrWhiteSpace(tokenResponse.AccessToken) ? tokenResponse.AccessToken : null;
        }
    }
}