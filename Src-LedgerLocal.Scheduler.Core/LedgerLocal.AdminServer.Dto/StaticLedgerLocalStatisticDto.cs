using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Dto
{
    public class StaticLedgerLocalStatisticDto
    {
        public StaticLedgerLocalStatisticDto()
        {
            Statistics = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Statistics { get; set; }

        public bool IsTradding { get; set; } = true;

        public bool IsSimulation { get; set; } = false;

        public int RetryTimeInSecond { get; set; } = 10;

        public DateTime BotStartDate { get; set; }
    }
}
