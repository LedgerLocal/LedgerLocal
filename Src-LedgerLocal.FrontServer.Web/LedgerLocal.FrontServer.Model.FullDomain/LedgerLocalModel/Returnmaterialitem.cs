using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Returnmaterialitem
    {
        public int Returnitemid { get; set; }
        public int? Returnid { get; set; }
        public int? Orderitemid { get; set; }
        public int? Returnmaterialreasonid { get; set; }
        public string Itemname { get; set; }
        public string Itemdescription { get; set; }
        public string Note { get; set; }
        public string Reason { get; set; }
        public bool Replace { get; set; }
        public int Quantity { get; set; }
        public int Quantityreceived { get; set; }
        public int Quantityreturnedtoinventory { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Orderitem Orderitem { get; set; }
        public Returnmaterial Return { get; set; }
        public Returnmaterialreason Returnmaterialreason { get; set; }
    }
}
