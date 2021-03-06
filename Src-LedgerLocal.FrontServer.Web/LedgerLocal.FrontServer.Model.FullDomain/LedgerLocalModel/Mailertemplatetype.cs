﻿using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailertemplatetype
    {
        public Mailertemplatetype()
        {
            Mailertemplate = new HashSet<Mailertemplate>();
        }

        public int Mailertypeid { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Mailertemplate> Mailertemplate { get; set; }
    }
}
