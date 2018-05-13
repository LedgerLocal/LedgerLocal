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
    public partial class CreateWorkerCreateOrUpdate
    {

        /*
         
owner_account: The account which owns the worker and will be paid
work_begin_date: When the work begins
work_end_date: When the work ends
daily_pay: Amount of pay per day (NOT per maint interval)
name: Any text
url: Any text
worker_settings: {“type” : “burn”|”refund”|”vesting”, “pay_vesting_period_days” : x}
broadcast: true if you wish to broadcast the transaction.

         */

        public CreateWorkerCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "ownerAccount")]
        public string OwnerAccount { get; set; }

        [DataMember(Name = "workBeginDate")]
        public DateTime WorkBeginDate { get; set; }

        [DataMember(Name = "workEndDate")]
        public DateTime WorkEndDate { get; set; }

        [DataMember(Name = "dailyPay")]
        public string DailyPay { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "workerSettings")]
        public string WorkerSettings { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
