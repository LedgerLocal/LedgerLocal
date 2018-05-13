using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Dto
{
    public class StaticLedgerLocalPortfolioDto
    {
        public string StrategyName { get; set; }
        
        public decimal MaxPercentOneFound { get; set; }

        public decimal MaxPercentTwoFound { get; set; }

        public int NumberOneTrades { get; set; } = 0;

        public int NumberTwoTrades { get; set; } = 0;

        public DateTime LastUtcTradeOne { get; set; }

        public DateTime LastUtcTradeTwo { get; set; }

        public DateTime LastPercentCalculation { get; set; }

        public long PercentCalculationSinceLastTrade { get; set; } = 0;

        public long NumberCrossDetectedForMarketOne { get; set; } = 0;

        public long NumberCrossDetectedForMarketTwo { get; set; } = 0;

        public long NumberCrossDetectedForMarketThree { get; set; } = 0;
    }
}
