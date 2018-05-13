using LedgerLocal.Blockchain.Service.KafkaMessager.Contract;
using LedgerLocal.Blockchain.Service.LycServiceContract.Architecture;

namespace LedgerLocal.Blockchain.Service.KafkaMessager
{
    public class KafkaFacade : IKafkaFacade
    {
        private IKafkaProducerConsumerFactory _kafkaProducerConsumerFactory;

        public KafkaFacade(IKafkaProducerConsumerFactory kafkaProducerConsumerFactory)
        {
            _kafkaProducerConsumerFactory = kafkaProducerConsumerFactory;
        }

        public IKafkaProducerConsumerFactory ProducerConsumerStore
        {
            get { return _kafkaProducerConsumerFactory; }    
        }
    }
}
