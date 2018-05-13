using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LedgerLocal.IdentityServer.FullNode.Web.Models;
using LedgerLocal.IdentityServer.FullNode.Web.Models.AccountViewModels;
using LedgerLocal.IdentityServer.FullNode.Web.Services;
using UserManagement.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Configuration;
using IdentityServer4;
using IdentityServer4.Validation;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using LedgerLocal.AdminServer.Api.Web.Models;
using Microsoft.AspNetCore.Cors;

namespace LedgerLocal.IdentityServer.FullNode.Web.Controllers
{
    [Authorize]
    [EnableCors("SiteCorsPolicy")]
    public class MemberAccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private ITokenService _ts;
        private IUserClaimsPrincipalFactory<User> _principalFactory;
        private IdentityServerOptions _option;

        public MemberAccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory,
            ITokenService ts,
            IUserClaimsPrincipalFactory<User> principalFactory,
            IdentityServerOptions option)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _ts = ts;
            _principalFactory = principalFactory;
            _option = option;
            _logger = loggerFactory.CreateLogger<MemberAccountController>();
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await _signInManager.SignOutAsync();

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");

                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        returnUrl = "/ManageHome";
                    }

                    return Redirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        returnUrl = "/ManageHome";
                    }

                    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        private async Task<string> GetToken(string userName, string audience)
        {
            var Request = new TokenCreationRequest();
            var User = await _userManager.FindByNameAsync(userName);
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
                foreach (var r1 in rolesClaim)
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
            return TokenValue;
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null, bool isTechnical = false)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                var queryStrings = Request.Query;

                if (queryStrings.ContainsKey("returnUrl"))
                {
                    returnUrl = queryStrings["returnUrl"];
                }
            }

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Registering starting: {model.Email}, redirect: {returnUrl}");

                if (!model.IsAgree)
                {
                    ModelState.AddModelError(string.Empty, "Please accept Terms and Conditions");
                    return View(model);
                }

                if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Count() < 4)
                {
                    ModelState.AddModelError(string.Empty, "Please use a 4 characters password.");
                    return View(model);
                }

                var user = new User { UserName = model.Email, Email = model.Email, GodFatherId = model.GodFatherId };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(nameof(ConfirmEmail), "MemberAccount", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

                    var message = @"LedgerLocal Register => {0}";
                    message = string.Format(message, callbackUrl);

                    await _emailSender.SendEmailAsync(model.Email, "Confirm your account", message);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    
                    if (!isTechnical)
                    {
                        var fNameCalculated = model.Email.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                        var modelCust = new CustomerCreateOrUpdate()
                        {
                            FirstName = fNameCalculated != null && fNameCalculated.Length > 0 ? fNameCalculated.First() : string.Empty,
                            LastName = string.Empty,
                            Email = model.Email,
                            Phone = string.Empty,
                            GodFatherId = !string.IsNullOrWhiteSpace(model.GodFatherId) ? model.GodFatherId : string.Empty
                        };

                        var t1 = await GetToken("identityuser@tokengenerator.tek", "api.main");

                        var _httpClient = new HttpClient();
                        _httpClient.SetBearerToken(t1);
                        var resFinal1 = await _httpClient.PostAsync($"https://www.ledgerlocal.com/api/customer/create",
                            new StringContent(JsonConvert.SerializeObject(modelCust), Encoding.UTF8, "application/json"));
                        resFinal1.EnsureSuccessStatusCode();

                        var resModel1String = await resFinal1.Content.ReadAsStringAsync();
                        var resModel1 = JsonConvert.DeserializeObject<CustomerProfile>(resModel1String);

                        user.CustomerId = resModel1.CustomerId;
                        user.GodFatherId = resModel1.GodFatherId;

                        await _userManager.UpdateAsync(user);

                        await _userManager.AddClaimAsync(user, new Claim("customerid", resModel1.CustomerId));
                        await _userManager.AddClaimAsync(user, new Claim("godfatherid", resModel1.GodFatherId));

                        //var lstRoles = new List<string>();

                        //lstRoles.Add("mainasset");
                        //lstRoles.Add("blockchainuser");
                        //lstRoles.Add("branch");
                        //lstRoles.Add("business");
                        //lstRoles.Add("coin");
                        //lstRoles.Add("coupon");
                        //lstRoles.Add("customer");
                        //lstRoles.Add("iot");
                        //lstRoles.Add("order");
                        //lstRoles.Add("point");
                        //lstRoles.Add("pos");
                        //lstRoles.Add("policy");
                        //lstRoles.Add("program");
                        //lstRoles.Add("qrcode");
                        //lstRoles.Add("return");
                        //lstRoles.Add("voucher");
                        //lstRoles.Add("workflow");

                        //await _userManager.AddToRolesAsync(user, lstRoles);
                    }
                    
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        returnUrl = "/ManageHome";
                    }
                    return Redirect(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/RegisterFromAdmin
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterFromAdmin([FromBody]RegisterViewModel model)
        {
            _logger.LogInformation($"[RegisterFromAdmin] Registering starting: {model.Email}, redirect: {null}");

            if (!model.IsAgree)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Count() < 4)
            {
                return null;
            }

            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {




//                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
//                // Send an email with this link
//                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                var callbackUrl = Url.Action(nameof(ConfirmEmail), "MemberAccount", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

//                var message = @"<b>Herzlich willkommen bei LedgerLocal,</b>
//<p>
//Sammeln Sie ab jetzt bei all unseren Partnerunternehmen Treuepunkte, tauschen Sie diese jederzeit und wählen Sie wann und wo immer sie diese einsetzen möchten – Sie haben die Wahl. 
//Alles ganz einfach auf Ihrem Telefon, digital, sofort sichtbar und ohne Papierverschwendung. LedgerLocal macht Ihre Treuepunkte tauschbar – dank Blockchain.
//</p>

//<b><p>
//*** Drücken Sie <a href = '{0}'>hier</a> um Ihr Email zu bestätigen ***
//</b></p>

//<p>
//Bei Fragen können Sie jederzeit unseren Kundenservice auf info@ledgerlocal.ch kontaktieren.
//</p>

//<p>
//Mit freundlichen Grüssen,<br />
//Ihr LedgerLocal Team
//</p>

//PS: Laden Sie jetzt die LedgerLocal App auf Ihr Telefon herunter (Iphone / Android), loggen Sie sich mit Ihrer Email Adresse und Ihrem neuen Passwort ein und sammeln ab jetzt bei unseren Partnerunternehmen Treuepunkte. 
//Mehr zu LedgerLocal erfahren Sie auf unserer website <a href = 'www.ledgerlocal.ch'>www.ledgerlocal.ch</a>";
//                message = string.Format(message, callbackUrl);

//                await _emailSender.SendEmailAsync(model.Email, "Confirm your account", message);
                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation(3, "User created a new account with password.");

                var fNameCalculated = model.Email.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                var modelCust = new CustomerCreateOrUpdate()
                {
                    FirstName = fNameCalculated != null && fNameCalculated.Length > 0 ? fNameCalculated.First() : string.Empty,
                    LastName = string.Empty,
                    Email = model.Email,
                    Phone = string.Empty
                };

            //var t1 = await GetToken("identityuser@tokengenerator.tek", "api.main");

            //var _httpClient = new HttpClient();
            //_httpClient.SetBearerToken(t1);
            //var resFinal1 = await _httpClient.PostAsync($"{""}/customer/create",
            //    new StringContent(JsonConvert.SerializeObject(modelCust), Encoding.UTF8, "application/json"));
            //resFinal1.EnsureSuccessStatusCode();

            //var resModel1String = await resFinal1.Content.ReadAsStringAsync();
            //var resModel1 = JsonConvert.DeserializeObject<CustomerProfile>(resModel1String);

            //user.CustomerId = resModel1.CustomerId;

            //await _userManager.UpdateAsync(user);

            //await _userManager.AddClaimAsync(user, new Claim("customerid", resModel1.CustomerId));

            //var lstRoles = new List<string>();

            //lstRoles.Add("mainasset");
            //lstRoles.Add("blockchainuser");
            //lstRoles.Add("branch");
            //lstRoles.Add("business");
            //lstRoles.Add("coin");
            //lstRoles.Add("coupon");
            //lstRoles.Add("customer");
            //lstRoles.Add("iot");
            //lstRoles.Add("order");
            //lstRoles.Add("point");
            //lstRoles.Add("pos");
            //lstRoles.Add("policy");
            //lstRoles.Add("program");
            //lstRoles.Add("qrcode");
            //lstRoles.Add("return");
            //lstRoles.Add("voucher");
            //lstRoles.Add("workflow");

            //await _userManager.AddToRolesAsync(user, lstRoles);

            return new ObjectResult(modelCust);
                
            }
            
            return null;
        }

        //
        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return RedirectToAction(nameof(MemberHomeController.Index), "MemberHome");
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        //
        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                _logger.LogInformation(5, "User logged in with {Name} provider.", info.LoginProvider);

                if (string.IsNullOrWhiteSpace(returnUrl))
                {
                    return RedirectToLocal(returnUrl);
                }

                return Redirect(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl });
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                if (!model.IsAgree)
                {
                    ModelState.AddModelError(string.Empty, "Please accept Terms and Conditions");
                    return View(model);
                }

                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        
                        var fNameCalculated = model.Email.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                        var modelCust = new CustomerCreateOrUpdate()
                        {
                            FirstName = fNameCalculated != null && fNameCalculated.Length > 0 ? fNameCalculated.First() : string.Empty,
                            LastName = string.Empty,
                            Email = model.Email,
                            Phone = string.Empty
                        };

                        //var t1 = await GetToken("identityuser@tokengenerator.tek", "api.main");

                        //var _httpClient = new HttpClient();
                        //_httpClient.SetBearerToken(t1);
                        //var resFinal1 = await _httpClient.PostAsync($"{""}/customer/create",
                        //    new StringContent(JsonConvert.SerializeObject(modelCust), Encoding.UTF8, "application/json"));
                        //resFinal1.EnsureSuccessStatusCode();

                        //var resModel1String = await resFinal1.Content.ReadAsStringAsync();
                        //var resModel1 = JsonConvert.DeserializeObject<CustomerProfile>(resModel1String);

                        //user.CustomerId = resModel1.CustomerId;

                        //await _userManager.UpdateAsync(user);

                        //await _userManager.AddClaimAsync(user, new Claim("customerid", resModel1.CustomerId));

                        //var lstRoles = new List<string>();

                        //lstRoles.Add("mainasset");
                        //lstRoles.Add("blockchainuser");
                        //lstRoles.Add("branch");
                        //lstRoles.Add("business");
                        //lstRoles.Add("coin");
                        //lstRoles.Add("coupon");
                        //lstRoles.Add("customer");
                        //lstRoles.Add("iot");
                        //lstRoles.Add("order");
                        //lstRoles.Add("point");
                        //lstRoles.Add("pos");
                        //lstRoles.Add("policy");
                        //lstRoles.Add("program");
                        //lstRoles.Add("qrcode");
                        //lstRoles.Add("return");
                        //lstRoles.Add("voucher");
                        //lstRoles.Add("workflow");

                        //await _userManager.AddToRolesAsync(user, lstRoles);

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation(6, "User created an account using {Name} provider.", info.LoginProvider);

                        if (string.IsNullOrWhiteSpace(returnUrl))
                        {
                            returnUrl = "/ManageHome";
                        }

                        return Redirect(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        // GET: /Account/ConfirmEmail
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)  //|| !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                // Construct the message
                var message = @"<b>Herzlich willkommen bei LedgerLocal</b>,

<p><b>
* **Drücken Sie <a href='{0}'>hier</a> um Ihr neues Passwort festzulegen***
</b></p>

<p>
Laden Sie die LedgerLocal App auf Ihr Telefon herunter(Iphone / Android), loggen Sie sich mit Ihrer Email Adresse und Ihrem neuen Passwort ein und sammeln ab jetzt bei unseren Partnerunternehmen Treuepunkte. 
Sie sehen Ihre Treuepunkte in Echtzeit auf dem Telefon, können diese jederzeit zwischen den Programmen tauschen und sofort dort einsetzen wo und wann sie möchten.
LedgerLocal macht Ihre Treuepunkte tauschbar – dank Blockchain. 
</p>

<p>
Bei Fragen können Sie jederzeit unseren Kundenservice auf info@ledgerlocal.ch kontaktieren.
</p>

<p>
Mit freundlichen Grüssen,<br />
Ihr LedgerLocal Team
</p>

<p>
PS: Mehr zu LedgerLocal erfahren Sie auf unserer website www.ledgerlocal.ch
</p>";

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action(nameof(ResetPassword), "MemberAccount", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                message = string.Format(message, callbackUrl);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                   message);
                return View("ForgotPasswordConfirmation");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(MemberAccountController.ResetPasswordConfirmation), "MemberAccount");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(MemberAccountController.ResetPasswordConfirmation), "MemberAccount");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/SendCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(user);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            // Generate the token and send it
            var code = await _userManager.GenerateTwoFactorTokenAsync(user, model.SelectedProvider);
            if (string.IsNullOrWhiteSpace(code))
            {
                return View("Error");
            }

            var message = "Your security code is: " + code;
            if (model.SelectedProvider == "Email")
            {
                await _emailSender.SendEmailAsync(await _userManager.GetEmailAsync(user), "Security Code", message);
            }
            else if (model.SelectedProvider == "Phone")
            {
                await _smsSender.SendSmsAsync(await _userManager.GetPhoneNumberAsync(user), message);
            }

            return RedirectToAction(nameof(VerifyCode), new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/VerifyCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyCode(string provider, bool rememberMe, string returnUrl = null)
        {
            // Require that the user has already logged in via username/password or external login
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes.
            // If a user enters incorrect codes for a specified amount of time then the user account
            // will be locked out for a specified amount of time.
            var result = await _signInManager.TwoFactorSignInAsync(model.Provider, model.Code, model.RememberMe, model.RememberBrowser);
            if (result.Succeeded)
            {
                if (string.IsNullOrWhiteSpace(model.ReturnUrl))
                {
                    model.ReturnUrl = "/ManageHome";
                }

                return Redirect(model.ReturnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning(7, "User account locked out.");
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid code.");
                return View(model);
            }
        }

        //
        // GET: /Account/AccessDenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(MemberHomeController.Index), "MemberHome");
            }
        }

        #endregion
    }
}
