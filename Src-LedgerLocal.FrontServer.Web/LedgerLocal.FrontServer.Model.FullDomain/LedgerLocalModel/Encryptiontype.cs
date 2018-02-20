using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Encryptiontype
    {
        public Encryptiontype()
        {
            User = new HashSet<User>();
        }

        public int Encryptionid { get; set; }
        public string Encryptionname { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<User> User { get; set; }
    }
}
