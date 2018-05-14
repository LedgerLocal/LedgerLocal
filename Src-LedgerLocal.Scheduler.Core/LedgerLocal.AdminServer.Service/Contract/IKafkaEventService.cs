using LedgerLocal.AdminServer.Api.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Service.LycServiceContract
{
    public interface IKafkaEventService
    {
        Task PoolMessageFromKafka(TimeSpan ts);
    }
}
