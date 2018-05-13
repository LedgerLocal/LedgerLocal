using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace LedgerLocal.Dto.Chain
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class OperationDescription
    {

        public OperationDescription()
        { 
        }

        [JsonProperty("fee")]
        public AmountDescription Fee { get; set; }

        [JsonProperty("amount")]
        public AmountDescription Amount { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("memo")]
        public MemoDescription Memo { get; set; }

    }
}
