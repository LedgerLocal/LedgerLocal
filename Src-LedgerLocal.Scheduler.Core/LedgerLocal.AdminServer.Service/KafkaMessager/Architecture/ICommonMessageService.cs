using LedgerLocal.AdminServer.Dto.Models;
using LedgerLocal.AdminServer.Service.KafkaMessager;
using LedgerLocal.AdminServer.Service.LedgerLocalServiceContract.Architecture;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Service.LedgerLocalServiceContract
{
    public interface ICommonMessageService
    {
        Task PoolMessageAsString(string sessionid, string topicName, TimeSpan timeSpan, Action<string, string, long, string> cb);

        Task SendMessageAsByte(string topicName, string key, byte[] val);

        Task SendMessageAsString(string topicName, string key, string val);

        void SendMessageAsStringSync(string topicName, string key, string val);

        void SendMessageAsByteSync(string topicName, string key, byte[] val);
    }
}
