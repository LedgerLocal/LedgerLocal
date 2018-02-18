using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class Log
    {
        public int LogId { get; set; }
        public Guid? LogGuid { get; set; }
        public DateTime LogDate { get; set; }
        public string Thread { get; set; }
        public string LogLevel { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Logger { get; set; }
        public string LogMessage { get; set; }
        public string LogInfo { get; set; }
    }
}
