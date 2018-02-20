using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Log
    {
        public int Logid { get; set; }
        public string Logguid { get; set; }
        public DateTime Logdate { get; set; }
        public string Thread { get; set; }
        public string Loglevel { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Logger { get; set; }
        public char Logmessage { get; set; }
        public string Loginfo { get; set; }
    }
}
