using LedgerLocal.AdminServer.Model.FullDomain;
using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Contentblockimagemap : BaseEntity
    {
        public int Contentblockimagemapid { get; set; }
        public int? Contentblockid { get; set; }
        public int? Imageid { get; set; }
        public bool Activate { get; set; }

        public Contentblock Contentblock { get; set; }
        public Image Image { get; set; }
    }
}
