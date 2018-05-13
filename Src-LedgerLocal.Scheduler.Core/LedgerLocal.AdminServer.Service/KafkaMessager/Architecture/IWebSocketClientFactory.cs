using LedgerLocal.Service.GrapheneLogic;
using System.Threading.Tasks;

namespace LedgerLocal.Blockchain.Service.KafkaMessager.Architecture
{
    public interface IWebSocketClientFactory
    {
        Task<WebSocketSession> GetContiniousSession(string assetSource, string assetDestination, string url);

        Task<WebSocketSession> GetSession(string url, string idString);

        Task<WebSocketSession> AddSession(string url, string idString);
    }
}
