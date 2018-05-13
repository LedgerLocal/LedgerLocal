namespace LedgerLocal.Blockchain.Service.LycServiceContract.Architecture
{
    public class KafkaConfigFactory : IKafkaConfigFactory
    {
        public KafkaConfigFactory(string kafkaUrl)
        {
            BrokerList = kafkaUrl;
        }

        public bool EnableAutoCommit => true;

        public string BrokerList { get; }
    }
}
