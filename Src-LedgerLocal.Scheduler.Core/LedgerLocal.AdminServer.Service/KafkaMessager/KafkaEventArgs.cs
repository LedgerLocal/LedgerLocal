using LedgerLocal.AdminServer.Service.KafkaMessager.KafkaReactive;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Blockchain.Service.KafkaMessager
{
    public struct KafkaEventArgs
    {
        public Try<Record<string, string>> Record { get; set; }
    }
}
