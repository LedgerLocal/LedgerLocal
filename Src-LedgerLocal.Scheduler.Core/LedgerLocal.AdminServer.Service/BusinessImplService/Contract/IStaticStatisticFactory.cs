using LedgerLocal.AdminServer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface IStaticStatisticFactory
    {
        StaticLedgerLocalStatisticDto GetStatistic { get; }
    }
}
