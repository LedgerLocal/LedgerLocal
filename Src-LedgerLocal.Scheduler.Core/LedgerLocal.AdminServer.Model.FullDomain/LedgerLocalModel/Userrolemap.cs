using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Userrolemap
    {
        public int Userrolemapid { get; set; }
        public int? Roleid { get; set; }
        public int? Userid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Userrole Role { get; set; }
        public User User { get; set; }
    }
}
