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
    public partial class VestingBalanceDescription
    {

        public VestingBalanceDescription()
        {
            
        }

        /// <summary>
        /// Gets or Sets AssetLabel
        /// </summary>
        [DataMember(Name="assetLabel")]
        public string AssetLabel { get; set; }
        /// <summary>
        /// Gets or Sets AssetSymbol
        /// </summary>
        [DataMember(Name="assetSymbol")]
        public string AssetSymbol { get; set; }
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name")]
        public string Name { get; set; }
        /// <summary>
        /// Created Voucher
        /// </summary>
        /// <value>Created Voucher</value>
        [DataMember(Name="timestamp")]
        public DateTime? Timestamp { get; set; }
        
    }
}
