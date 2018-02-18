using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LedgerLocal.FrontServer.WebApi.ActionResult
{
    public class ErrorContentResult : ContentResult
    {
        public ErrorContentResult(string content)
        {
            StatusCode = 500;
            Content = content;
        }
    }
}
