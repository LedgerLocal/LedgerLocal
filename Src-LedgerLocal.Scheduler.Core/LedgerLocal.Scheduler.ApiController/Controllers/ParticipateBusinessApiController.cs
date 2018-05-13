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
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
    public class ParticipateBusinessApiController : Controller
    { 
        private readonly ILedgerLocalBusinessService _businessService;
        private readonly IDbContextService _dbContext;

        public ParticipateBusinessApiController(ILedgerLocalBusinessService businessService, IDbContextService dbContext)
        {
            _businessService = businessService;
            _dbContext = dbContext;
        }

        
    }
}
