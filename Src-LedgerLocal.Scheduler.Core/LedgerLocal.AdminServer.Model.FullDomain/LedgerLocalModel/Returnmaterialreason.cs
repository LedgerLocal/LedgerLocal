﻿using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Returnmaterialreason
    {
        public Returnmaterialreason()
        {
            Returnmaterialitem = new HashSet<Returnmaterialitem>();
        }

        public int Returnmaterialreasonid { get; set; }
        public string Reasoncode { get; set; }
        public string Reasonname { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Returnmaterialitem> Returnmaterialitem { get; set; }
    }
}
