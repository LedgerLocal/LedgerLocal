
using Confluent.Kafka;

namespace LedgerLocal.AdminServer.Service.KafkaMessager.KafkaReactive
{
    public class Record<TK, TV>
    {
        private readonly TK _key;
        private readonly TV _value;

        public Record(TK key, TV value)
        {
            _key = key;
            _value = value;
        }

        public TK Key { get { return _key; } }

        public TV Value { get { return _value; } }

        public Message<TK, TV> MessageRaw { get; set; }
    }
}
