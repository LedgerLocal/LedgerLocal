using LedgerLocal.FrontServer.Service.LedgerLocalServiceContract.Architecture;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Service.KafkaMessager.Contract
{
    public interface IKafkaFacade<T>
    {
        IKafkaProducerConsumerFactory<T> ProducerConsumerStore { get; }
    }
}
