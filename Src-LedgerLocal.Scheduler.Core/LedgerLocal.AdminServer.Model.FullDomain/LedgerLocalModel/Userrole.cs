using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Userrole
    {
        public Userrole()
        {
            Rolepermissionmap = new HashSet<Rolepermissionmap>();
            Userrolemap = new HashSet<Userrolemap>();
        }

        public int Roleid { get; set; }
        public string Rolename { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Rolepermissionmap> Rolepermissionmap { get; set; }
        public ICollection<Userrolemap> Userrolemap { get; set; }
    }
}
