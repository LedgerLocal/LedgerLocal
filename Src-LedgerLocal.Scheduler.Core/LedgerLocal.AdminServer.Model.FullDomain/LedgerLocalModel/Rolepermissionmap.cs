using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Rolepermissionmap
    {
        public int Rolepermissionmapid { get; set; }
        public int? Roleid { get; set; }
        public int? Rolepermissionid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Userrole Role { get; set; }
        public Rolepermission Rolepermission { get; set; }
    }
}
