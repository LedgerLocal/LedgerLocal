using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using LedgerLocal.FrontServer.Service.Contract;
using LedgerLocal.FrontServer.Service.BusinessImplService.Contract;

namespace LedgerLocal.FrontServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
    public class BusinessApiController : Controller
    { 
        private readonly ILedgerLocalBusinessService _businessService;
        private readonly IDbContextService _dbContext;

        public BusinessApiController(ILedgerLocalBusinessService businessService, IDbContextService dbContext)
        {
            _businessService = businessService;
            _dbContext = dbContext;
        }

        
    }
}
