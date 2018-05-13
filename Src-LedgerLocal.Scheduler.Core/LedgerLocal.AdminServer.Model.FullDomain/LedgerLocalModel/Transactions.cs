using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Transactions
    {
        public int Transactionid { get; set; }
        public int? Currencyid { get; set; }
        public int? Userid { get; set; }
        public long Amount { get; set; }
        public decimal Amountusd { get; set; }
        public long Amounttoken { get; set; }
        public long? Godfathercode { get; set; }
        public decimal? Purchaseprice { get; set; }
        public string Memobc { get; set; }
        public bool? Paidonbc { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Currency Currency { get; set; }
        public User User { get; set; }
    }
}
