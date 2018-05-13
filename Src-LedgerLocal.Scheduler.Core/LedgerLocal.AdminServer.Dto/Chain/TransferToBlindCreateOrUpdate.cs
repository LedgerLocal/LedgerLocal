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
    public partial class TransferToBlindCreateOrUpdate
    {

        public TransferToBlindCreateOrUpdate()
        {
            ToAmounts = new List<Tuple<string, string>>();
        }

        [DataMember(Name = "accountIdOrName")]
        public string AccountIdOrName { get; set; }

        [DataMember(Name = "assetSymbol")]
        public string AssetSymbol { get; set; }

        [DataMember(Name = "toAmounts")]
        public List<Tuple<string, string>> ToAmounts { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
