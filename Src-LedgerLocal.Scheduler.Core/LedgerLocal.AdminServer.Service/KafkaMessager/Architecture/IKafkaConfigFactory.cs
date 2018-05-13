using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service.LedgerLocalServiceContract
{
    public interface IKafkaConfigFactory
    {
        bool EnableAutoCommit { get; }
        string BrokerList { get; }
    }
}
