using LedgerLocal.AdminServer.Service.KafkaMessager.Contract;
using LedgerLocal.AdminServer.Service.LedgerLocalServiceContract.Architecture;

namespace LedgerLocal.AdminServer.Service.KafkaMessager
{
    public class KafkaFacade<T> : IKafkaFacade<T>
    {
        private IKafkaProducerConsumerFactory<T> _kafkaProducerConsumerFactory;

        public KafkaFacade(IKafkaProducerConsumerFactory<T> kafkaProducerConsumerFactory)
        {
            _kafkaProducerConsumerFactory = kafkaProducerConsumerFactory;
        }

        public IKafkaProducerConsumerFactory<T> ProducerConsumerStore
        {
            get { return _kafkaProducerConsumerFactory; }    
        }
    }
}
