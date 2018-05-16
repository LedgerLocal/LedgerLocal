using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class WithdrawBusinessService : IWithdrawBusinessService
    {

        public bool ValidateAddress(string bitshareAddress)
        {
            return true;
        }

        public void InitiateTransfer(string customerId, string bitshareAddress)
        {

        }

    }
}
