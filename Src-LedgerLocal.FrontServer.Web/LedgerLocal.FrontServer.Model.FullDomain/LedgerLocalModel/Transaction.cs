using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Transaction
    {
        public int Transactionid { get; set; }
        public int Orderid { get; set; }
        public int Processorid { get; set; }
        public int? Creditcardtypeid { get; set; }
        public int? Transactionstatusid { get; set; }
        public DateTime Transactiondate { get; set; }
        public decimal Amount { get; set; }
        public string Authorizationcode { get; set; }
        public decimal Amountauthorized { get; set; }
        public decimal Amountcharged { get; set; }
        public decimal Amountrefunded { get; set; }
        public string Checknumber { get; set; }
        public DateTime? Creditcardexp { get; set; }
        public string Creditcardholder { get; set; }
        public string Creditcardnumber { get; set; }
        public string Creditcardencrypted { get; set; }
        public string Creditcardcvn { get; set; }
        public string Giftcertificatenumber { get; set; }
        public string Transactionreferencenumber { get; set; }
        public string Transactionresponsecode { get; set; }
        public string Note { get; set; }
        public int Pointofsaleid { get; set; }
        public long? Coinledgerid { get; set; }
        public int? Programid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Creditcardtype Creditcardtype { get; set; }
        public Order Order { get; set; }
        public Transactionprocessor Processor { get; set; }
        public Transactionstatus Transactionstatus { get; set; }
    }
}
