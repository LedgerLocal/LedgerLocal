using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class PeopleOnlineHistory
    {
        public int PeopleOnlineHistoryId { get; set; }
        public int? UserId { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public DateTime FirstActivity { get; set; }
        public DateTime? EndActivity { get; set; }
        public decimal? DurationMinute { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual User User { get; set; }
    }
}
