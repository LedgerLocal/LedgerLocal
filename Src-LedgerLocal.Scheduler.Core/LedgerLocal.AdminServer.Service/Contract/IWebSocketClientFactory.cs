using LedgerLocal.Service.GrapheneLogic;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Service.Contract
{
    public interface IWebSocketClientFactory
    {
        Task<WebSocketSession> GetContiniousSession(string assetSource, string assetDestination, string url);

        Task<WebSocketSession> GetSession(string url, string idString);

        Task<WebSocketSession> AddSession(string url, string idString);
    }
}
