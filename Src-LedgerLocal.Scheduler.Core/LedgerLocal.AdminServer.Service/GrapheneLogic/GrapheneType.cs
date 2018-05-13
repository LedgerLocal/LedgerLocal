using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic
{
    /*
	 *		"NULL"                           :  "1.0.%d",
            "BASE"                           :  "1.1.%d",
            "ACCOUNT"                        :  "1.2.%d",
            "FORCE_SETTLEMENT"               :  "1.3.%d",
            "ASSET"                          :  "1.4.%d",
            "DELEGATE"                       :  "1.5.%d",
            "WITNESS"                        :  "1.6.%d",
            "LIMIT_ORDER"                    :  "1.7.%d",
            "CALL_ORDER"                     :  "1.8.%d",
            "CUSTOM"                         :  "1.9.%d",
            "PROPOSAL"                       :  "1.10.%d",
            "OPERATION_HISTORY"              :  "1.11.%d",
            "WITHDRAW_PERMISSION"            :  "1.12.%d",
            "VESTING_BALANCE"                :  "1.13.%d",
            "WORKER"                         :  "1.14.%d",
            "BALANCE"                        :  "1.15.%d",
            "GLOBAL_PROPERTY"                :  "2.0.%d",
            "DYNAMIC_GLOBAL_PROPERTY"        :  "2.1.%d",
            "INDEX_META"                     :  "2.2.%d",
            "ASSET_DYNAMIC_DATA"             :  "2.3.%d",
            "ASSET_BITASSET_DATA"            :  "2.4.%d",
            "DELEGATE_FEEDS"                 :  "2.5.%d",
            "ACCOUNT_BALANCE"                :  "2.6.%d",
            "ACCOUNT_STATISTICS"             :  "2.7.%d",
            "ACCOUNT_DEBT"                   :  "2.8.%d",
            "TRANSACTION"                    :  "2.9.%d",
            "BLOCK_SUMMARY"                  :  "2.10.%d",
            "ACCOUNT_TRANSACTION_HISTORY"    :  "2.11.%d",
            "WITNESS_SCHEDULE"               :  "2.12.%d",
	 */

    public enum GrapheneObjectTypes
    {
        @null = 0,
        @base,
        account,
        force_settlement,
        asset,
        @delegate,
        witness,
        limit_order,
        call_order,
        custom,
        proposal,
        operation_history,
        withdraw_permission,
        vesting_balance,
        worker,
        balance,

        MIDDLE,

        global_property,
        dynamic_global_property,
        index_meta,
        asset_dynamic_data,
        asset_bitasset_data,
        delegate_feeds,
        account_balance,
        account_statistics,
        account_debt,
        transaction,
        block_summary,
        account_transaction_history,
        witness_schedule,
    }

    public class GraphenePermission
    {
        public GraphenePermission()
        {
            AccountAuths = new List<Dictionary<string, int>>();
            KeyAuths = new List<Dictionary<string, int>>();
            AddressAuths = new List<Dictionary<string, int>>();
        }

        [JsonProperty("weight_threshold")]
        public int WeightThreshold { get; set; }

        [JsonProperty("account_auths")]
        public List<Dictionary<string, int>> AccountAuths { get; set; }

        [JsonProperty("key_auths")]
        public List<Dictionary<string, int>> KeyAuths { get; set; }

        [JsonProperty("address_auths")]
        public List<Dictionary<string, int>> AddressAuths { get; set; }
    }

    public class GrapheneAccountOptions
    {
        [JsonProperty("memo_key")]
        public string MemoKey { get; set; }

        [JsonProperty("voting_account")]
        public string VotingAccount { get; set; }

        [JsonProperty("num_witness")]
        public int NumWitness { get; set; }

        [JsonProperty("num_committee")]
        public int NumCommittee { get; set; }
    }

    /// <summary>	A graphene account. </summary>
    ///		
    ///		{id:1.2.29495,
    ///		membership_expiration_date:1970-01-01T00:00:00,
    ///		registrar:1.2.4,
    ///		referrer:1.2.0,
    ///		lifetime_referrer:1.2.0,
    ///		network_fee_percentage:2000,
    ///		lifetime_referrer_fee_percentage:3000,
    ///		referrer_rewards_percentage:0,
    ///		name:monsterer,
    ///		owner:
    ///		{
    ///			weight_threshold:1,
    ///			account_auths:[],
    ///			key_auths:[[BTS8RwSWSFcnzWLBfXuvG4XkqSqeuDaqMzoMr6V5LRX2ietxF8APy,1]],
    ///			address_auths:[]
    ///		},
    ///		active:
    ///		{
    ///			weight_threshold:2,
    ///			account_auths:[[1.2.31211,1]],
    ///			key_auths:[[BTS8RwSWSFcnzWLBfXuvG4XkqSqeuDaqMzoMr6V5LRX2ietxF8APy,1]],
    ///			address_auths:[]
    ///		},
    ///		options:
    ///		{
    ///			memo_key:BTS8RwSWSFcnzWLBfXuvG4XkqSqeuDaqMzoMr6V5LRX2ietxF8APy,
    ///			voting_account:1.2.5,
    ///			num_witness:0,
    ///			num_committee:0,
    ///			votes:[],
    ///			extensions:[]
    ///		},
    ///		statistics:2.6.29495,
    ///		whitelisting_accounts:[],
    ///		blacklisting_accounts:[],
    ///		blacklisted_accounts:[]
    ///		}
    ///
    /// 
    /// <remarks>	Paul, 19/10/2015. </remarks>
    public class GrapheneAccount
    {
        public GrapheneAccount()
        {
            WhitelistingAccounts = new List<string>();
            BlacklistingAccounts = new List<string>();
            BlacklistedAccounts = new List<string>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("membership_expiration_date")]
        public DateTime MembershipExpirationDate { get; set; }

        [JsonProperty("registrar")]
        public string Registrar { get; set; }

        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        [JsonProperty("lifetime_referrer")]
        public string LifetimeReferrer { get; set; }

        [JsonProperty("network_fee_percentage")]
        public int NetworkFeePercentage { get; set; }

        [JsonProperty("lifetime_referrer_fee_percentage")]
        public int LifetimeReferrerFeePercentage { get; set; }

        [JsonProperty("referrer_rewards_percentage")]
        public int ReferrerRewardsPercentage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public GraphenePermission Owner { get; set; }

        [JsonProperty("active")]
        public GraphenePermission Active { get; set; }

        [JsonProperty("options")]
        public GrapheneAccountOptions Options { get; set; }

        [JsonProperty("statistics")]
        public string Statistics { get; set; }

        [JsonProperty("whitelisting_accounts")]
        public List<string> WhitelistingAccounts { get; set; }

        [JsonProperty("blacklisting_accounts")]
        public List<string> BlacklistingAccounts { get; set; }

        [JsonProperty("blacklisted_accounts")]
        public List<string> BlacklistedAccounts { get; set; }
    }

    /// <summary>	A graphene object. </summary>
    ///
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneObject
    {
        GrapheneObjectTypes m_type;
        uint m_index;
        string m_raw;

        public GrapheneObject(string descriptor)
        {
            m_raw = descriptor;
            string[] parts = descriptor.Split('.');

            if (parts.Length == 3)
            {
                m_type = (GrapheneObjectTypes)System.Enum.Parse(typeof(GrapheneObjectTypes), parts[1]);

                if (parts[0] == "2")
                {
                    m_type = (GrapheneObjectTypes)((uint)m_type + (int)GrapheneObjectTypes.MIDDLE + 1);
                }

                m_index = uint.Parse(parts[2]);
            }
        }

        public GrapheneObject(uint a, uint b, uint c) : this(a + "." + b + "." + c) { }

        public override string ToString()
        {
            return m_raw;
        }

        public uint GetIndex() { return m_index; }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(GrapheneObject a, GrapheneObject b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(GrapheneObject a, GrapheneObject b)
        {
            return !(a == b);
        }
    }

    /// <summary>	A graphene asset quantity. </summary>
    ///
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneAmount
    {
        [JsonProperty("amount")]
        public ulong Amount { get; set; }

        [JsonProperty("asset_id")]
        public string Asset_id { get; set; }
    }

    /// <summary>	A grpahene exchange rate. </summary>
    ///
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneExchangeRate
    {
        [JsonProperty("base")]
        public GrapheneAmount Base { get; set; }

        [JsonProperty("quote")]
        public GrapheneAmount Quote { get; set; }
    }

    public class GrapheneAssetCreator
    {
        [JsonProperty("fee")]
        public GrapheneAmount Fee { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("precision")]
        public ulong Precision { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("common_options")]
        public GrapheneAssetOptions Options { get; set; }

        [JsonProperty("bitasset_opts")]
        public GrapheneBitAssetOptions BitAssetOptions { get; set; }

        [JsonProperty("is_prediction_market")]
        public bool Is_prediction_market { get; set; }
    }

    public class GrapheneAssetIssued
    {
        [JsonProperty("fee")]
        public GrapheneAmount Fee { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("asset_to_issue")]
        public GrapheneAmount AssetToIssue { get; set; }

        [JsonProperty("issue_to_account")]
        public string IssueToAccount { get; set; }

        [JsonProperty("memo")]
        public GrapheneMemo Memo { get; set; }
    }

    /// <summary>	A graphene asset. </summary>
    ///
    /// {
    ///		id:1.3.0,
    ///		symbol:BTS,
    ///		precision:5,
    ///		issuer:1.2.3,
    ///		options:
    ///		{
    ///			max_supply:360057050210207,
    ///			market_fee_percent:0,
    ///			max_market_fee:1000000000000000,
    ///			issuer_permissions:0,
    ///			flags:0,
    ///			core_exchange_rate:
    ///			{
    ///				base:{amount:1,asset_id:1.3.0},
    ///				quote:{amount:1,asset_id:1.3.0}
    ///			},
    ///			whitelist_authorities:[],
    ///			blacklist_authorities:[],
    ///			whitelist_markets:[],
    ///			blacklist_markets:[],
    ///			description:,
    ///			extensions:[]
    ///		},
    ///		dynamic_asset_data_id:2.3.0
    ///	}
    ///
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneAsset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("precision")]
        public ulong Precision { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("options")]
        public GrapheneAssetOptions Options { get; set; }

        [JsonProperty("dynamic_asset_data_id")]
        public string Dynamic_asset_data_id { get; set; }

        public decimal GetPrecisionDividor()
        {
            return (decimal)Math.Pow(10, Precision);
        }

        public decimal GetAmountFromLarimers(ulong larmiers)
        {
            return (decimal)larmiers / GetPrecisionDividor();
        }

        public ulong GetLarimersFromAmount(decimal amount)
        {
            return (ulong)(GetPrecisionDividor() * amount);
        }

        public decimal Truncate(decimal amount)
        {
            decimal div = GetPrecisionDividor();
            return (ulong)(Math.Max(amount, 0) * div) / div;
        }

        //public bool IsUia()
        //{
        //    return this.Issuer.GetIndex() > 3;
        //}
    }

    public class GrapheneIssuerPermissions
    {
        [JsonProperty("charge_market_fee")]
        public bool ChargeMarketFee { get; set; } = false;

        [JsonProperty("white_list")]
        public bool WhiteList { get; set; } = false;

        [JsonProperty("override_authority")]
        public bool OverrideAuthority { get; set; } = false;

        [JsonProperty("transfer_restricted")]
        public bool TransferRestricted { get; set; } = false;

        [JsonProperty("disable_force_settle")]
        public bool DisableForceSettle { get; set; } = false;

        [JsonProperty("global_settle")]
        public bool GlobalSettle { get; set; } = false;

        [JsonProperty("disable_confidential")]
        public bool DisableConfidential { get; set; } = false;

        [JsonProperty("witness_fed_asset")]
        public bool WitnessFedAsset { get; set; } = false;

        [JsonProperty("committee_fed_asset")]
        public bool CommitteeFedAsset { get; set; } = false;
    }

    /// <summary>	A graphene asset options. </summary>
    ///
    /// <remarks>	Paul, 20/10/2015. </remarks>

    /*
  
        perm = {}
perm["charge_market_fee"] = 0x01
perm["white_list"] = 0x02
perm["override_authority"] = 0x04
perm["transfer_restricted"] = 0x08
perm["disable_force_settle"] = 0x10
perm["global_settle"] = 0x20
perm["disable_confidential"] = 0x40
perm["witness_fed_asset"] = 0x80
perm["committee_fed_asset"] = 0x100


class Config():
    wallet_host           = "localhost"
    wallet_port           = 8092
    wallet_user           = ""
    wallet_password       = ""

if __name__ == '__main__':
    graphene = GrapheneClient(Config)

    permissions = {"charge_market_fee" : True,
                   "white_list" : True,
                   "override_authority" : True,
                   "transfer_restricted" : True,
                   "disable_force_settle" : True,
                   "global_settle" : True,
                   "disable_confidential" : True,
                   "witness_fed_asset" : True,
                   "committee_fed_asset" : True,
                   }
    flags       = {"charge_market_fee" : False,
                   "white_list" : False,
                   "override_authority" : False,
                   "transfer_restricted" : False,
                   "disable_force_settle" : False,
                   "global_settle" : False,
                   "disable_confidential" : False,
                   "witness_fed_asset" : False,
                   "committee_fed_asset" : False,
                   }

     */


    public class GrapheneAssetOptions
    {
        public GrapheneAssetOptions()
        {
            Whitelist_authorities = new List<string>();
            Blacklist_authorities = new List<string>();
            Whitelist_markets = new List<string>();
            Blacklist_markets = new List<string>();
        }

        [JsonProperty("max_supply")]
        public ulong Max_supply { get; set; }

        [JsonProperty("market_fee_percent")]
        public decimal Market_fee_percent { get; set; }

        [JsonProperty("max_market_fee")]
        public ulong Max_market_fee { get; set; }

        [JsonProperty("issuer_permissions")]
        public uint Issuer_permissions { get; set; }

        [JsonProperty("flags")]
        public uint Flags { get; set; }

        [JsonProperty("core_exchange_rate")]
        public GrapheneExchangeRate Core_exchange_rate { get; set; }

        [JsonProperty("whitelist_authorities")]
        public List<string> Whitelist_authorities { get; set; }

        [JsonProperty("blacklist_authorities")]
        public List<string> Blacklist_authorities { get; set; }

        [JsonProperty("whitelist_markets")]
        public List<string> Whitelist_markets { get; set; }

        [JsonProperty("blacklist_markets")]
        public List<string> Blacklist_markets { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_prediction_market")]
        public bool IsPredictionMarket { get; set; }
    }

    /// <summary>	A graphene memo. </summary>
    ///
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneMemo
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("nonce")]
        public ulong Nonce { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    /// <summary>	A graphene operation. </summary>
    ///
    ///		{
    ///        "fee": 
    ///        {
    ///          "amount": 2089843,
    ///          "asset_id": "1.3.0"
    ///        },
    ///        "from": "1.2.17",
    ///        "to": "1.2.7",
    ///        "amount": 
    ///        {
    ///          "amount": 10000000,
    ///          "asset_id": "1.3.0"
    ///        },
    ///        "memo": 
    ///        {
    ///          "from": "GPH6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV",
    ///          "to": "GPH6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV",
    ///          "nonce": "16430576185191232340",
    ///          "message": "74d0e455e2e5587b7dc85380102c3291"
    ///        },
    ///        "extensions": []
    ///      }
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneOperation
    {
        [JsonProperty("fee")]
        public GrapheneAmount Fee { get; set; }

        [JsonProperty("amount")]
        public GrapheneAmount Amount { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("memo")]
        public GrapheneMemo Memo { get; set; }
    }

    /// <summary>	Information about the graphene transaction. </summary>
    ///
    /// {
    ///  "ref_block_num": 18,
    ///  "ref_block_prefix": 2320098938,
    ///  "expiration": "2015-10-13T13:56:15",
    ///  "operations": [[
    ///      0,{
    ///        "fee": {
    ///          "amount": 2089843,
    ///          "asset_id": "1.3.0"
    ///        },
    ///        "from": "1.2.17",
    ///        "to": "1.2.7",
    ///        "amount": {
    ///          "amount": 10000000,
    ///          "asset_id": "1.3.0"
    ///        },
    ///        "memo": {
    ///          "from": "GPH6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV",
    ///          "to": "GPH6MRyAjQq8ud7hVNYcfnVPJqcVpscN5So8BhtHuGYqET5GDW5CV",
    ///          "nonce": "16430576185191232340",
    ///          "message": "74d0e455e2e5587b7dc85380102c3291"
    ///        },
    ///        "extensions": []
    ///      }
    ///    ]
    ///  ],
    ///  "extensions": [],
    ///  "signatures": [
    ///    "1f147aed197a2925038e4821da54bd7818472ebe25257ac9a7ea66429494e7242d0dc13c55c6840614e6da6a5bf65ae609a436d13a3174fd12f073550f51c8e565"
    ///  ]
    /// }
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneTransactionRecord<T>
    {
        public GrapheneTransactionRecord()
        {
            Operations = new List<Dictionary<string, T>>();
            Signatures = new List<string>();
        }

        [JsonProperty("ref_block_num")]
        public ulong RefBlockNum { get; set; }

        [JsonProperty("ref_block_prefix")]
        public ulong RefBlockPrefix { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("operations")]
        public List<Dictionary<string, T>> Operations { get; set; }

        [JsonProperty("signatures")]
        public List<string> Signatures { get; set; }

        [JsonProperty("trx_in_block")]
        public int TrxInBlock { get; set; }

        [JsonProperty("block_num")]
        public ulong BlockNum { get; set; }
    }

    /// <summary>	Information about the graphene. </summary>
    ///
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneInfo
    {
        public GrapheneInfo()
        {
            ActiveWitnesses = new List<string>();
            ActiveCommitteeMembers = new List<string>();
        }

        [JsonProperty("head_block_num")]
        public ulong HeadNlockNum { get; set; }

        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        [JsonProperty("head_block_age")]
        public string HeadBlockAge { get; set; }

        [JsonProperty("next_maintenance_time")]
        public string NextMaintenanceTime { get; set; }

        [JsonProperty("chain_id")]
        public string ChainId { get; set; }

        [JsonProperty("participation")]
        public decimal Participation { get; set; }

        [JsonProperty("active_witnesses")]
        public List<string> ActiveWitnesses { get; set; }

        [JsonProperty("active_committee_members")]
        public List<string> ActiveCommitteeMembers { get; set; }
    }

    /// <summary>	A graphene block. </summary>
    ///
    /// {
    ///		previous:000309e96012e54e43b6d9e3aa8ada24137b6f48,
    ///		timestamp:2015-10-20T15:49:06,
    ///		witness:1.6.21,
    ///		transaction_merkle_root:0000000000000000000000000000000000000000,
    ///		extensions:[],
    ///		witness_signature:20383eea8fb3e0ede4fa99c95d436253aaa24ac35030292ce10d92978f29498bd6653a81e2f3c97ed8d6ee21307e36fe25fb08a0003a1dd1af0d3a27cded45635f,
    ///		transactions:[],
    ///		block_id:000309ea2fc1134ea5145b1208f1a6870f9fc9a0,
    ///		signing_key:BTS5ARpXg6yWZptHgik721dyXek57v53op6XT7rwTj7Kmb8CGwWEM
    ///	}
    /// <remarks>	Paul, 20/10/2015. </remarks>
    public class GrapheneBlock
    {
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("witness")]
        public string Witness { get; set; }

        [JsonProperty("transaction_merkle_root")]
        public string TransactionMerkleRoot { get; set; }

        [JsonProperty("witness_signature")]
        public string WitnessSignature { get; set; }

        [JsonProperty("transactions")]
        public List<GrapheneTransactionRecord<GrapheneOperation>> Transactions { get; set; }

        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("signing_key")]
        public string SigningKey { get; set; }

        [JsonProperty("transaction_ids")]
        public List<string> TransactionIds { get; set; }
    }

    /// <summary>	A graphene order. </summary>
    ///
    ///	{
    ///   	"id": "1.7.1148",
    ///    "expiration": "2020-10-20T17:33:00",
    ///    "seller": "1.2.18208",
    ///    "for_sale": 8033,
    ///    "sell_price": {
    ///      "base": {
    ///        "amount": 18533,
    ///        "asset_id": "1.3.121"
    ///      },
    ///      "quote": {
    ///        "amount": 49112450,
    ///        "asset_id": "1.3.0"
    ///      }
    ///    }
    /// <remarks>	Paul, 21/10/2015. </remarks>
    public class GrapheneOrder
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

        [JsonProperty("for_sale")]
        public ulong ForSale { get; set; }

        [JsonProperty("sell_price")]
        public GrapheneExchangeRate SellPrice { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        public decimal GetPrice(bool bid, decimal ratio)
        {
            if (bid)
            {
                return (decimal)(SellPrice.Base.Amount / ratio) / (decimal)SellPrice.Quote.Amount;
            }
            else
            {
                return (decimal)(SellPrice.Quote.Amount / ratio) / (decimal)SellPrice.Base.Amount;
            }
        }
    }

    public class GrapheneOpContainer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("op")]
        public Dictionary<int, GrapheneOperation> Op { get; set; }

        [JsonProperty("result")]
        public Dictionary<int, string> Result { get; set; }

        [JsonProperty("block_num")]
        public ulong BlockNum { get; set; }

        [JsonProperty("trx_in_block")]
        public ulong TrxInBlock { get; set; }

        [JsonProperty("op_in_trx")]
        public ulong OpInTrx { get; set; }

        [JsonProperty("virtual_op")]
        public ulong VirtualOp { get; set; }
    }

    public class GrapheneOperationHistoryItem
    {
        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("op")]
        public GrapheneOpContainer Op { get; set; }
    }

    public class GrapheneApiIndex
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data")]
        public int Data { get; set; }
    }

    /// <summary>	A graphene dynamic asset data. </summary>
    /// {
    ///		"id": "2.3.416",
    ///    "current_supply": 2158569,
    ///    "confidential_supply": 0,
    ///    "accumulated_fees": 0,
    ///    "fee_pool": 0
    ///   }
    ///
    /// <remarks>	Paul, 24/10/2015. </remarks>
    public class GrapheneDynamicAssetData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("current_supply")]
        public ulong CurrentSupply { get; set; }

        [JsonProperty("confidential_supply")]
        public ulong ConfidentialSupply { get; set; }

        [JsonProperty("accumulated_fees")]
        public ulong AccumulatedFees { get; set; }

        [JsonProperty("fee_pool")]
        public ulong FeePool { get; set; }
    }
}
