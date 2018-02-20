using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailinglist
    {
        public Mailinglist()
        {
            Mailinglistcontentblockmap = new HashSet<Mailinglistcontentblockmap>();
            Mailinglistimagemap = new HashSet<Mailinglistimagemap>();
            Mailinglistproductmap = new HashSet<Mailinglistproductmap>();
            Mailinglistqueue = new HashSet<Mailinglistqueue>();
        }

        public int Mailinglistid { get; set; }
        public int? Mailertemplateid { get; set; }
        public int? Mailinglistpeoplegroupid { get; set; }
        public string Mailinglistcode { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Mailertemplate Mailertemplate { get; set; }
        public Mailinglistpeoplegroup Mailinglistpeoplegroup { get; set; }
        public ICollection<Mailinglistcontentblockmap> Mailinglistcontentblockmap { get; set; }
        public ICollection<Mailinglistimagemap> Mailinglistimagemap { get; set; }
        public ICollection<Mailinglistproductmap> Mailinglistproductmap { get; set; }
        public ICollection<Mailinglistqueue> Mailinglistqueue { get; set; }
    }
}
