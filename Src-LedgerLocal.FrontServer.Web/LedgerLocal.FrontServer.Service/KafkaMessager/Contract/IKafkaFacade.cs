using LedgerLocal.Blockchain.Service.LycServiceContract.Architecture;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Blockchain.Service.KafkaMessager.Contract
{
    public interface IKafkaFacade
    {
        IKafkaProducerConsumerFactory ProducerConsumerStore { get; }
    }
}
