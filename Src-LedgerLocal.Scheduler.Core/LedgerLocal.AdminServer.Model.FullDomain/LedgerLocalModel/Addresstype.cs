﻿using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Addresstype
    {
        public Addresstype()
        {
            Address = new HashSet<Address>();
        }

        public int Addresstypeid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
