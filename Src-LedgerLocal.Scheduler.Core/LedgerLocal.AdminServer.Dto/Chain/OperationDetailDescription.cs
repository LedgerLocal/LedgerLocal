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
    public partial class OperationDetailDescription
    {

        public OperationDetailDescription()
        {
            
        }


        [DataMember(Name="assetLabel")]
        public string AssetLabel { get; set; }
        
        
    }
}
