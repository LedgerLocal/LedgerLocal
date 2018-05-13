using System;
using System.Threading.Tasks;

namespace LedgerLocal.Blockchain.Service.LycServiceContract
{
    public interface ICommonMessageService
    {
        Task SendMessage<T>(string topicName, string key, T val) where T : class;

        Task PoolMessage<T>(string topicName, TimeSpan timeSpan, Action<string, string, T> cb) where T : class;

        Task<CommonMessageEncapsulator<T>> ConsumeMessage<T>(string topicName, string key, TimeSpan timeSpan) where T : class;
        
    }
}
