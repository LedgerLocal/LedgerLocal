using LedgerLocal.FrontServer.Model.FullDomain;
using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Contentblockculturemap : BaseEntity
    {
        public int Contentblockculturemapid { get; set; }
        public int? Contentblockid { get; set; }
        public int? Cultureid { get; set; }
        public string Content { get; set; }
        public bool Activate { get; set; }
        public Contentblock Contentblock { get; set; }
        public Culture Culture { get; set; }
    }
}
