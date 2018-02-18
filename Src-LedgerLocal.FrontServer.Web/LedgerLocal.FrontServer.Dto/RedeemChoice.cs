using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Dto
{
    public class RedeemChoice
    {
        public string CustomerId { get; set; }

        public string[] VoucherIds { get; set; }
    }
}
