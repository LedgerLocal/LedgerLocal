using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Dto
{
    public class RedeemRequest
    {
        public string CustomerId { get; set; }

        public string CoinId { get; set; }

        public decimal OrderAmount { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}
