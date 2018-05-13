using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Rolepermission
    {
        public Rolepermission()
        {
            Rolepermissionmap = new HashSet<Rolepermissionmap>();
        }

        public int Rolepermissionid { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Rolepermissionmap> Rolepermissionmap { get; set; }
    }
}
