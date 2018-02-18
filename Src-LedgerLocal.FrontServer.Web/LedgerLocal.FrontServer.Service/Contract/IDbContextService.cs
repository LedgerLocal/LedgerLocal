using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service.Contract
{
    public interface IDbContextService
    {
        void RefreshFullDomain();
    }
}
