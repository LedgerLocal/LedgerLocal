using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Returnmaterial
    {
        public Returnmaterial()
        {
            Returnmaterialitem = new HashSet<Returnmaterialitem>();
        }

        public int Returnid { get; set; }
        public int? Orderid { get; set; }
        public int? Returnstatusid { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Emailaddress { get; set; }
        public string Phonenumber { get; set; }
        public char Comment { get; set; }
        public DateTime Dateofreturn { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Order Order { get; set; }
        public Returnmaterialstatus Returnstatus { get; set; }
        public ICollection<Returnmaterialitem> Returnmaterialitem { get; set; }
    }
}
