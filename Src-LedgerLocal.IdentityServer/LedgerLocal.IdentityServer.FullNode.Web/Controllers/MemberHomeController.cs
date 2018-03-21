using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LedgerLocal.IdentityServer.FullNode.Web.Controllers
{
    public class MemberHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "LedgerLocal Vault description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "LedgerLocal AG contact.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
