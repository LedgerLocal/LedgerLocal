using LedgerLocal.Dto.Chain;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.Service.GrapheneLogic.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class GrapheneWallet
    {
        public const int kBitsharesMaxAccountNameLength = 63;

        GrapheneHttpSocketWrapper m_cliWallet;
        //GrapheneHttpSocketWrapper m_blockchain;

        private IWebSocketClientFactory _wsClientFact;

        /// <summary>	Constructor. </summary>
        ///
        /// <remarks>	Paul, 26/11/2014. </remarks>
        ///
        /// <param name="rpcUrl">	  	Bitshares RPC root url. </param>
        /// <param name="rpcUsername">	The RPC username. </param>
        /// <param name="rpcPassword">	The RPC password. </param>
        public GrapheneWallet(IWebSocketClientFactory wsClientFact)
        {
            ConfigureSerialisation();

            _wsClientFact = wsClientFact;
        }

        public async Task<bool> StartAndConnect(List<CliCredential> creds)
        {
            var gWallet = new GrapheneHttpSocketWrapper(_wsClientFact);
            await gWallet.Connect(creds[0].Url);
            m_cliWallet = gWallet;
            return true;
        }

        /// <summary>	Configure serialisation. </summary>
        ///
        /// <remarks>	Paul, 19/10/2015. </remarks>
        static public void ConfigureSerialisation()
        {
            // configure servicestack.text to be able to parse the bitshares rpc responses
            //JsConfig<decimal>.DeSerializeFn = s => decimal.Parse(s, NumberStyles.Float);
            //JsConfig<GrapheneObject>.DeSerializeFn = s => new GrapheneObject(s);
            //JsConfig<GrapheneObject>.SerializeFn = o => o.ToString();
            //JsConfig.DateHandler = JsonDateHandler.ISO8601;
            //JsConfig.IncludeTypeInfo = false;
            //JsConfig.IncludePublicFields = true;
            //JsConfig.IncludeNullValues = true;
        }

        /// <summary>	API call. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="method">	The method. </param>
        /// <param name="args">  	A variable-length parameters list containing arguments. </param>
        ///
        /// <returns>	A T. </returns>
        public async Task<T> ApiCallAsync<T>(GrapheneMethodEnum method, GrapheneApi api, params object[] args)
        {
            return await m_cliWallet.ApiCall<T>(method, api, args);
        }

        /// <summary>	API call. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="method">	The method. </param>
        /// <param name="args">  	A variable-length parameters list containing arguments. </param>
        ///
        /// <returns>	A T. </returns>
        public T ApiCall<T>(GrapheneMethodEnum method, GrapheneApi api, params object[] args)
        {
            return m_cliWallet.ApiCallSync<T>(method, api, args);
        }

        /// <summary>	API call blockchain. </summary>
        ///
        /// <remarks>	Paul, 23/10/2015. </remarks>
        ///
        /// <typeparam name="T">	Generic type parameter. </typeparam>
        /// <param name="method">	The method. </param>
        /// <param name="args">  	A variable-length parameters list containing arguments. </param>
        ///
        /// <returns>	A T. </returns>
        public T ApiCallBlockchain<T>(GrapheneMethodEnum method, GrapheneApi api, params object[] args)
        {
            return m_cliWallet.ApiCallSync<T>(method, api, args);
            //return m_blockchain.ApiCallSync<T>(method, api, args);
        }

        /// <summary>	Gets an account. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="account">	The account. </param>
        ///
        /// <returns>	The account. </returns>
        public GrapheneAccount GetAccount(string account)
        {
            return ApiCall<GrapheneAccount>(GrapheneMethodEnum.get_account, GrapheneApi.@public, account);
        }

        /// <summary>	Gets an asset. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="symbol">	The symbol. </param>
        ///
        /// <returns>	The asset. </returns>
        public GrapheneAsset GetAsset(string symbol)
        {
            return ApiCall<GrapheneAsset>(GrapheneMethodEnum.get_asset, GrapheneApi.@public, symbol);
        }

        public BitassetDataDescription GetBitasset(string symbol)
        {
            return ApiCall<BitassetDataDescription>(GrapheneMethodEnum.get_bitasset_data, GrapheneApi.@public, symbol);
        }

        /// <summary>	Gets an object. </summary>
        ///
        /// <remarks>	Paul, 24/10/2015. </remarks>
        ///
        /// <typeparam name="T">	Generic type parameter. </typeparam>
        /// <param name="id">	The identifier. </param>
        ///
        /// <returns>	The object. </returns>
        public T GetObject<T>(GrapheneObject id)
        {
            return ApiCall<T[]>(GrapheneMethodEnum.get_object, GrapheneApi.@public, id)[0];
        }

        /// <summary>	List account balances. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="account">	The account. </param>
        ///
        /// <returns>	A Task&lt;GrapheneAmount[]&gt; </returns>
        public GrapheneAmount[] ListAccountBalances(string account)
        {
            return ApiCall<GrapheneAmount[]>(GrapheneMethodEnum.list_account_balances, GrapheneApi.@public, account);
        }

        /// <summary>	List assets. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <returns>	A Task&lt;GrapheneAsset[]&gt; </returns>
        public GrapheneAsset[] ListAssets(string startSymbol = "", int limit = 100)
        {
            return ApiCall<GrapheneAsset[]>(GrapheneMethodEnum.list_assets, GrapheneApi.@public, startSymbol, limit);
        }

        public string[][] ListAccounts(string startAccount = "", int limit = 100)
        {
            return ApiCall<string[][]>(GrapheneMethodEnum.list_accounts, GrapheneApi.@public, startAccount, limit);
        }

        /// <summary>	Transfers. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="from">			Source for the. </param>
        /// <param name="to">			to. </param>
        /// <param name="amount">   	The amount. </param>
        /// <param name="symbol">   	The symbol. </param>
        /// <param name="memo">			(Optional) the memo. </param>
        /// <param name="broadcast">	(Optional) true to broadcast. </param>
        ///
        /// <returns>	A Task&lt;GrapheneTransactionRecord&gt; </returns>
        public Dictionary<string, GrapheneTransactionRecord<GrapheneOperation>> Transfer(string from, string to, decimal amount, string symbol, string memo = "")
        {
            return ApiCall<Dictionary<string, GrapheneTransactionRecord<GrapheneOperation>>>(GrapheneMethodEnum.transfer2, GrapheneApi.@public, from, to, Numeric.SerialisedDecimal(amount), symbol, memo);
        }

        /// <summary>	Issue asset. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="to">			to. </param>
        /// <param name="amount">   	The amount. </param>
        /// <param name="symbol">   	The symbol. </param>
        /// <param name="memo">			(Optional) the memo. </param>
        /// <param name="broadcast">	(Optional) true to broadcast. </param>
        ///
        /// <returns>	A Task&lt;GrapheneTransactionRecord&gt; </returns>
        public GrapheneTransactionRecord<GrapheneAssetIssued> IssueAsset(string to, decimal amount, string symbol, string memo = "", bool broadcast = true)
        {
            return ApiCall<GrapheneTransactionRecord<GrapheneAssetIssued>>(GrapheneMethodEnum.issue_asset, GrapheneApi.@public, to, amount, symbol, memo, broadcast);
        }

        public GrapheneTransactionRecord<GrapheneAssetCreator> CreateAsset(string issuer, string symbol, uint precision, GrapheneAssetOptions common, GrapheneBitAssetOptions bitassetOpts, bool broadcast = false)
        {
            if (bitassetOpts == null)
            {
                return ApiCall<GrapheneTransactionRecord<GrapheneAssetCreator>>(GrapheneMethodEnum.create_asset, GrapheneApi.@public,
                    issuer, symbol, precision,
                    common, JValue.CreateNull(), broadcast);
            }

            return ApiCall<GrapheneTransactionRecord<GrapheneAssetCreator>>(GrapheneMethodEnum.create_asset, GrapheneApi.@public, 
                issuer, symbol, precision, 
                common, bitassetOpts, 
                broadcast);
        }

        public GrapheneTransactionRecord<GrapheneAssetCreator> BorrowAsset(string borrower_name, decimal amount_to_borrow, string asset_symbol, decimal amount_of_collateral, bool broadcast = false)
        {
            return ApiCall<GrapheneTransactionRecord<GrapheneAssetCreator>>(GrapheneMethodEnum.borrow_asset, GrapheneApi.@public, borrower_name, Numeric.SerialisedDecimal(amount_to_borrow), asset_symbol, Numeric.SerialisedDecimal(amount_of_collateral), broadcast);
        }

        public GrapheneTransactionRecord<GrapheneAssetCreator> PublishAssetFeed(string publishing_account, string symbol, GraphenePriceFeed feed, bool broadcast = false)
        {
            return ApiCall<GrapheneTransactionRecord<GrapheneAssetCreator>>(GrapheneMethodEnum.publish_asset_feed, GrapheneApi.@public, publishing_account, symbol, feed, broadcast);
        }

        /// <summary>	Burn uia. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="account">  	The account. </param>
        /// <param name="amount">   	The amount. </param>
        /// <param name="symbol">   	The symbol. </param>
        /// <param name="broadcast">	(Optional) true to broadcast. </param>
        ///
        /// <returns>	A Task&lt;GrapheneTransactionRecord&gt; </returns>
        public Dictionary<string, GrapheneTransactionRecord<GrapheneOperation>> BurnUia(string account, decimal amount, string symbol)
        {
            return ApiCall<Dictionary<string, GrapheneTransactionRecord<GrapheneOperation>>>(GrapheneMethodEnum.reserve_asset2, GrapheneApi.@public, account, Numeric.SerialisedDecimal(amount), symbol);
        }

        /// <summary>	Gets the information. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <returns>	A Task&lt;GrapheneInfo&gt; </returns>
        public GrapheneInfo Info()
        {
            return ApiCall<GrapheneInfo>(GrapheneMethodEnum.info, GrapheneApi.@public);
        }

        /// <summary>	Gets a transaction. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="txid">	The txid. </param>
        ///
        /// <returns>	The transaction. </returns>
        public GrapheneTransactionRecord<GrapheneOperation> GetTransaction(uint blockNum, uint transactionInBlock)
        {
            return ApiCallBlockchain<GrapheneTransactionRecord<GrapheneOperation>>(GrapheneMethodEnum.get_transaction, GrapheneApi.@public, blockNum, transactionInBlock);
        }

        /// <summary>	Gets recent transaction. </summary>
        ///
        /// <remarks>	Paul, 23/10/2015. </remarks>
        ///
        /// <param name="txid">	The txid. </param>
        ///
        /// <returns>	The recent transaction. </returns>
        public GrapheneTransactionRecord<GrapheneOperation> GetRecentTransaction(string txid)
        {
            return ApiCallBlockchain<GrapheneTransactionRecord<GrapheneOperation>>(GrapheneMethodEnum.get_recent_transaction_by_id, GrapheneApi.@public, txid);
        }

        /// <summary>	Gets a block. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="height">	The height. </param>
        ///
        /// <returns>	The block. </returns>
        public GrapheneBlock GetBlock(ulong height)
        {
            return ApiCall<GrapheneBlock>(GrapheneMethodEnum.get_block, GrapheneApi.@public, height);
        }

        /// <summary>	Limit orders. </summary>
        ///
        /// <remarks>	Paul, 21/10/2015. </remarks>
        ///
        /// <param name="quoteSymbol">	The quote symbol. </param>
        /// <param name="baseSymbol"> 	The base symbol. </param>
        /// <param name="limit">	  	The limit. </param>
        ///
        /// <returns>	A GrapheneOrder[]. </returns>
        public GrapheneOrder[] LimitOrders(string baseSymbol, string quoteSymbol, int limit)
        {
            GrapheneAsset quote = GetAsset(quoteSymbol);
            GrapheneAsset @base = GetAsset(baseSymbol);

            GrapheneOrder[] orderbook = ApiCall<GrapheneOrder[]>(GrapheneMethodEnum.get_limit_orders, GrapheneApi.@public, baseSymbol, quoteSymbol, limit);

            for (int i = 0; i < limit; i++)
            {
                decimal bp0 = @base.GetAmountFromLarimers(orderbook[i].SellPrice.Base.Amount);
                decimal qp0 = quote.GetAmountFromLarimers(orderbook[i].SellPrice.Quote.Amount);
                decimal bp1 = quote.GetAmountFromLarimers(orderbook[i + limit].SellPrice.Base.Amount);
                decimal qp1 = @base.GetAmountFromLarimers(orderbook[i + limit].SellPrice.Quote.Amount);

                orderbook[i].Price = qp0 / bp0;
                orderbook[i + limit].Price = bp1 / qp1;
            }

            return orderbook;
        }

        /// <param name="account">	The account. </param>
        /// <param name="limit">  	The limit. </param>
        ///
        /// <returns>	An array of graphene operation history item. </returns>
        public GrapheneOpContainer[] GetAccountHistory(string account, uint limit)
        {
            return ApiCallBlockchain<GrapheneOpContainer[]>(GrapheneMethodEnum.get_account_history, GrapheneApi.history, account, limit);
        }

        /// <summary>	Gets private key. </summary>
        ///
        /// <remarks>	Paul, 26/10/2015. </remarks>
        ///
        /// <param name="publicKey">	The public key. </param>
        ///
        /// <returns>	The private key. </returns>
        public string GetPrivateKey(string publicKey)
        {
            return ApiCall<string>(GrapheneMethodEnum.get_private_key, GrapheneApi.@public, publicKey);
        }

        /// <summary>	Query if 'name' is valid account name. </summary>
        ///
        /// <remarks>	Paul, 20/10/2015. </remarks>
        ///
        /// <param name="name">	The name. </param>
        ///
        /// <returns>	true if valid account name, false if not. </returns>
        public static bool IsValidAccountName(string name)
        {
            string regExPattern = @"^([\-\.a-z0-9]+)$";
            return Regex.IsMatch(name, regExPattern) && name.Length <= kBitsharesMaxAccountNameLength;
        }

        /// <summary>	Gets all transfers. </summary>
        ///
        /// <remarks>	Paul, 21/10/2015. </remarks>
        ///
        /// <param name="t">	The GrapheneTransactionRecord to process. </param>
        ///
        /// <returns>	all transfers. </returns>
        static public List<GrapheneOperation> GetAllTransfers(GrapheneTransactionRecord<GrapheneOperation> t)
        {
            List<GrapheneOperation> allTransfers = new List<GrapheneOperation>();

            foreach (var outer in t.Operations)
            {
                IEnumerable<GrapheneOperation> ops = outer.Select<KeyValuePair<string, GrapheneOperation>, GrapheneOperation>(kvp => kvp.Value);

                IEnumerable<GrapheneOperation> transfers = ops.Where(o => o.From != null && o.To != null);

                allTransfers.AddRange(transfers);
            }

            return allTransfers;
        }
    }
}
