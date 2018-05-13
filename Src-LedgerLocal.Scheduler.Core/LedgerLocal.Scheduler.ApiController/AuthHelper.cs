using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;
using LedgerLocal.AdminServer.Service;

namespace LedgerLocal.AdminServer.ApiController
{
    public static class AuthHelper
    {
        public static bool CheckIfValidCustomerId(this ClaimsPrincipal user, string cutomerId, bool throwExp = false)
        {
            var testBool = false;

            var ci1 = user.Identity as ClaimsIdentity;
            if (ci1 != null)
            {
                var cClaim1 = ci1.Claims.Where(x => x.Type.ToLowerInvariant() == "customerid").FirstOrDefault();

                if (cClaim1 != null)
                {
                    if (cClaim1.Value == cutomerId)
                    {
                        testBool = true;
                    }
                }

                var rClaims1 = ci1.Claims.Where(x => x.Value.ToLowerInvariant() == "service:secured").FirstOrDefault();

                if (rClaims1 != null)
                {
                    testBool = true;
                }

                if (throwExp && !testBool)
                {
                    var l1 = ServiceLocatorSingleton.Instance.ServiceProvider.GetService<ILogger<ServiceLocatorSingleton>>();

                    l1.LogError("Exception Cross Check Customer");

                    foreach (var cl in ci1.Claims)
                    {
                        l1.LogError($"the current user claim => type: {cl.Type}, Value: {cl.Value}");
                    }

                    throw new UnauthorizedAccessException("The customer is invalid (Cross-Customer Check Violation)");
                }
            }

            return testBool;
        }
    }
}
