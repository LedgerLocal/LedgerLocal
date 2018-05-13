using LedgerLocal.AdminServer.Service.LedgerLocalServiceContract.Architecture;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service.KafkaMessager.Contract
{
    public interface IKafkaFacade<T>
    {
        IKafkaProducerConsumerFactory<T> ProducerConsumerStore { get; }
    }
}
