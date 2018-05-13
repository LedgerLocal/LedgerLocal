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
    public partial class FundAssetFeePoolCreateOrUpdate
    {

        public FundAssetFeePoolCreateOrUpdate()
        {
            
        }

        [DataMember(Name= "from")]
        public string From { get; set; }

        [DataMember(Name= "symbol")]
        public string Symbol { get; set; }

        [DataMember(Name= "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
