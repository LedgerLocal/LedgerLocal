/*
 * Restler API Explorer
 *
 * Live API Documentation
 *
 * OpenAPI spec version: 1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// TransactionInfo Model
    /// </summary>
    [DataContract]
    public partial class TransactionInfo : IEquatable<TransactionInfo>
    { 
        /// <summary>
        /// an ID that uniquely identifies this transaction on BlockTrades
        /// </summary>
        /// <value>an ID that uniquely identifies this transaction on BlockTrades</value>
        [Required]
        [DataMember(Name="transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The current status of this transaction
        /// </summary>
        /// <value>The current status of this transaction</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum TransactionProcessingStateEnum
        {
            
            /// <summary>
            /// Enum TransactionSeenEnum for transaction_seen
            /// </summary>
            [EnumMember(Value = "transaction_seen")]
            TransactionSeenEnum = 1,
            
            /// <summary>
            /// Enum TransactionFullyConfirmedEnum for transaction_fully_confirmed
            /// </summary>
            [EnumMember(Value = "transaction_fully_confirmed")]
            TransactionFullyConfirmedEnum = 2,
            
            /// <summary>
            /// Enum NoOutputMappingEnum for no_output_mapping
            /// </summary>
            [EnumMember(Value = "no_output_mapping")]
            NoOutputMappingEnum = 3,
            
            /// <summary>
            /// Enum PermanentOutputFailureUnauthorizedInputCurrencyEnum for permanent_output_failure_unauthorized_input_currency
            /// </summary>
            [EnumMember(Value = "permanent_output_failure_unauthorized_input_currency")]
            PermanentOutputFailureUnauthorizedInputCurrencyEnum = 4,
            
            /// <summary>
            /// Enum PermanentOutputFailureUnauthorizedOutputCurrencyEnum for permanent_output_failure_unauthorized_output_currency
            /// </summary>
            [EnumMember(Value = "permanent_output_failure_unauthorized_output_currency")]
            PermanentOutputFailureUnauthorizedOutputCurrencyEnum = 5,
            
            /// <summary>
            /// Enum PermanentOutputFailureInputTooSmallEnum for permanent_output_failure_input_too_small
            /// </summary>
            [EnumMember(Value = "permanent_output_failure_input_too_small")]
            PermanentOutputFailureInputTooSmallEnum = 6,
            
            /// <summary>
            /// Enum PermanentOutputFailureManuallyRefundedEnum for permanent_output_failure_manually_refunded
            /// </summary>
            [EnumMember(Value = "permanent_output_failure_manually_refunded")]
            PermanentOutputFailureManuallyRefundedEnum = 7,
            
            /// <summary>
            /// Enum PermanentOutputFailureInvalidTransactionEnum for permanent_output_failure_invalid_transaction
            /// </summary>
            [EnumMember(Value = "permanent_output_failure_invalid_transaction")]
            PermanentOutputFailureInvalidTransactionEnum = 8,
            
            /// <summary>
            /// Enum OutputWalletUnreachableEnum for output_wallet_unreachable
            /// </summary>
            [EnumMember(Value = "output_wallet_unreachable")]
            OutputWalletUnreachableEnum = 9,
            
            /// <summary>
            /// Enum InsufficientFundsInHotWalletToSendOutputEnum for insufficient_funds_in_hot_wallet_to_send_output
            /// </summary>
            [EnumMember(Value = "insufficient_funds_in_hot_wallet_to_send_output")]
            InsufficientFundsInHotWalletToSendOutputEnum = 10,
            
            /// <summary>
            /// Enum InsufficientLiquidityEnum for insufficient_liquidity
            /// </summary>
            [EnumMember(Value = "insufficient_liquidity")]
            InsufficientLiquidityEnum = 11,
            
            /// <summary>
            /// Enum OutputTransactionInitiatedEnum for output_transaction_initiated
            /// </summary>
            [EnumMember(Value = "output_transaction_initiated")]
            OutputTransactionInitiatedEnum = 12,
            
            /// <summary>
            /// Enum AwaitingOrderFillEnum for awaiting_order_fill
            /// </summary>
            [EnumMember(Value = "awaiting_order_fill")]
            AwaitingOrderFillEnum = 13,
            
            /// <summary>
            /// Enum UnknownErrorScanningInputEnum for unknown_error_scanning_input
            /// </summary>
            [EnumMember(Value = "unknown_error_scanning_input")]
            UnknownErrorScanningInputEnum = 14,
            
            /// <summary>
            /// Enum UnknownErrorSendingOutputEnum for unknown_error_sending_output
            /// </summary>
            [EnumMember(Value = "unknown_error_sending_output")]
            UnknownErrorSendingOutputEnum = 15,
            
            /// <summary>
            /// Enum OutputTransactionBroadcastEnum for output_transaction_broadcast
            /// </summary>
            [EnumMember(Value = "output_transaction_broadcast")]
            OutputTransactionBroadcastEnum = 16,
            
            /// <summary>
            /// Enum OutputTransactionFullyConfirmedEnum for output_transaction_fully_confirmed
            /// </summary>
            [EnumMember(Value = "output_transaction_fully_confirmed")]
            OutputTransactionFullyConfirmedEnum = 17,
            
            /// <summary>
            /// Enum NoRefundAddressEnum for no_refund_address
            /// </summary>
            [EnumMember(Value = "no_refund_address")]
            NoRefundAddressEnum = 18,
            
            /// <summary>
            /// Enum UnknownErrorComputingOutputEnum for unknown_error_computing_output
            /// </summary>
            [EnumMember(Value = "unknown_error_computing_output")]
            UnknownErrorComputingOutputEnum = 19,
            
            /// <summary>
            /// Enum ClaimingSuretyEnum for claiming_surety
            /// </summary>
            [EnumMember(Value = "claiming_surety")]
            ClaimingSuretyEnum = 20,
            
            /// <summary>
            /// Enum UnknownErrorClaimingSuretyEnum for unknown_error_claiming_surety
            /// </summary>
            [EnumMember(Value = "unknown_error_claiming_surety")]
            UnknownErrorClaimingSuretyEnum = 21,
            
            /// <summary>
            /// Enum OutputApprovedBeforeFullyConfirmedEnum for output_approved_before_fully_confirmed
            /// </summary>
            [EnumMember(Value = "output_approved_before_fully_confirmed")]
            OutputApprovedBeforeFullyConfirmedEnum = 22,
            
            /// <summary>
            /// Enum OutputSentBeforeFullyConfirmedEnum for output_sent_before_fully_confirmed
            /// </summary>
            [EnumMember(Value = "output_sent_before_fully_confirmed")]
            OutputSentBeforeFullyConfirmedEnum = 23
        }

        /// <summary>
        /// The current status of this transaction
        /// </summary>
        /// <value>The current status of this transaction</value>
        [Required]
        [DataMember(Name="transactionProcessingState")]
        public TransactionProcessingStateEnum? TransactionProcessingState { get; set; }

        /// <summary>
        /// the time BlockTrades first detected the input transaction on the network
        /// </summary>
        /// <value>the time BlockTrades first detected the input transaction on the network</value>
        [Required]
        [DataMember(Name="inputFirstSeenTime")]
        public string InputFirstSeenTime { get; set; }

        /// <summary>
        /// the time BlockTrades detected that the input transaction has become fully confirmed (requirements vary by coin type). null if never fully confirmed.
        /// </summary>
        /// <value>the time BlockTrades detected that the input transaction has become fully confirmed (requirements vary by coin type). null if never fully confirmed.</value>
        [DataMember(Name="inputFullyConfirmedTime")]
        public string InputFullyConfirmedTime { get; set; }

        /// <summary>
        /// the number of confirmations BlockTrades has seen on this transaction. This is only tracked until we consider the input fully confirmed.
        /// </summary>
        /// <value>the number of confirmations BlockTrades has seen on this transaction. This is only tracked until we consider the input fully confirmed.</value>
        [Required]
        [DataMember(Name="inputNumberOfConfirmations")]
        public long? InputNumberOfConfirmations { get; set; }

        /// <summary>
        /// the amount of the input transaction, in nominal units of the inputCoinType
        /// </summary>
        /// <value>the amount of the input transaction, in nominal units of the inputCoinType</value>
        [Required]
        [DataMember(Name="inputAmount")]
        public string InputAmount { get; set; }

        /// <summary>
        /// the transaction ID of the input transaction. The format varies, but this will be the transaction ID the user sees in their client, and will be able to look up this transaction ID on a block explorer.
        /// </summary>
        /// <value>the transaction ID of the input transaction. The format varies, but this will be the transaction ID the user sees in their client, and will be able to look up this transaction ID on a block explorer.</value>
        [Required]
        [DataMember(Name="inputTransactionHash")]
        public string InputTransactionHash { get; set; }

        /// <summary>
        /// the type of cryptocoin deposited
        /// </summary>
        /// <value>the type of cryptocoin deposited</value>
        [Required]
        [DataMember(Name="inputCoinType")]
        public string InputCoinType { get; set; }

        /// <summary>
        /// the type of cryptocoin wallet (this is implicit in the inputCoinType, included here only for convenience)
        /// </summary>
        /// <value>the type of cryptocoin wallet (this is implicit in the inputCoinType, included here only for convenience)</value>
        [Required]
        [DataMember(Name="inputWalletType")]
        public string InputWalletType { get; set; }

        /// <summary>
        /// the address at which BlockTrades received the deposit. Format varies, but will be a valid address on the input network.
        /// </summary>
        /// <value>the address at which BlockTrades received the deposit. Format varies, but will be a valid address on the input network.</value>
        [Required]
        [DataMember(Name="inputAddress")]
        public string InputAddress { get; set; }

        /// <summary>
        /// if we were able to detect the address that sent the input, it will be recorded here, null otherwise. If we had to issue a refund and the user didn&#39;t explicitly supply a refund address, this is our best guess where to send it.
        /// </summary>
        /// <value>if we were able to detect the address that sent the input, it will be recorded here, null otherwise. If we had to issue a refund and the user didn&#39;t explicitly supply a refund address, this is our best guess where to send it.</value>
        [DataMember(Name="primarySourceAddress")]
        public string PrimarySourceAddress { get; set; }

        /// <summary>
        /// the time we processed the transaction and sent the user their desired output, or null if not yet processed
        /// </summary>
        /// <value>the time we processed the transaction and sent the user their desired output, or null if not yet processed</value>
        [DataMember(Name="outputInitiationTime")]
        public string OutputInitiationTime { get; set; }

        /// <summary>
        /// the amount of the output transaction, in nominal units of the outputCoinType (this is the amount the user will receive, it does not include the transaction fee we pay). null if not yet processed.
        /// </summary>
        /// <value>the amount of the output transaction, in nominal units of the outputCoinType (this is the amount the user will receive, it does not include the transaction fee we pay). null if not yet processed.</value>
        [DataMember(Name="outputAmount")]
        public string OutputAmount { get; set; }

        /// <summary>
        /// the transaction ID of the output transaction. The format varies, but this will be the transaction ID the user sees in their client, and will be able to look up this transaction ID on a block explorer.
        /// </summary>
        /// <value>the transaction ID of the output transaction. The format varies, but this will be the transaction ID the user sees in their client, and will be able to look up this transaction ID on a block explorer.</value>
        [DataMember(Name="outputTransactionHash")]
        public string OutputTransactionHash { get; set; }

        /// <summary>
        /// the type of cryptocoin sent to the user, null if not yet processed
        /// </summary>
        /// <value>the type of cryptocoin sent to the user, null if not yet processed</value>
        [DataMember(Name="outputCoinType")]
        public string OutputCoinType { get; set; }

        /// <summary>
        /// the type of cryptocoin wallet (this is implicit in the outputCoinType, included here only for convenience)
        /// </summary>
        /// <value>the type of cryptocoin wallet (this is implicit in the outputCoinType, included here only for convenience)</value>
        [DataMember(Name="outputWalletType")]
        public string OutputWalletType { get; set; }

        /// <summary>
        /// the address/public key/account name to which BlockTrades sent the requested funds.
        /// </summary>
        /// <value>the address/public key/account name to which BlockTrades sent the requested funds.</value>
        [DataMember(Name="outputAddress")]
        public string OutputAddress { get; set; }

        /// <summary>
        /// the memo BlockTrades will use/used when sending outputs
        /// </summary>
        /// <value>the memo BlockTrades will use/used when sending outputs</value>
        [DataMember(Name="outputMemo")]
        public string OutputMemo { get; set; }

        /// <summary>
        /// The nickname associated with the output address. If the user hasn&#39;t assigned a nickname for this address, one will be generated and shown here.
        /// </summary>
        /// <value>The nickname associated with the output address. If the user hasn&#39;t assigned a nickname for this address, one will be generated and shown here.</value>
        [DataMember(Name="outputAddressNickname")]
        public string OutputAddressNickname { get; set; }

        /// <summary>
        /// The time we last updated information about this transaction in our database. When requesting a list of transactions, you can ask for only transactions where this field is newer than a specified time.
        /// </summary>
        /// <value>The time we last updated information about this transaction in our database. When requesting a list of transactions, you can ask for only transactions where this field is newer than a specified time.</value>
        [DataMember(Name="lastModifiedTime")]
        public string LastModifiedTime { get; set; }

        /// <summary>
        /// For pending transactions, this is the number of confirmations we will require before sending the corresponding output
        /// </summary>
        /// <value>For pending transactions, this is the number of confirmations we will require before sending the corresponding output</value>
        [Required]
        [DataMember(Name="requiredNumberOfInputConfirmations")]
        public string RequiredNumberOfInputConfirmations { get; set; }

        /// <summary>
        /// the input coin amount in USD equivalent, this is calculated as the equivalent USD amount based on the rate at transaction time
        /// </summary>
        /// <value>the input coin amount in USD equivalent, this is calculated as the equivalent USD amount based on the rate at transaction time</value>
        [Required]
        [DataMember(Name="inputUsdEquivalent")]
        public string InputUsdEquivalent { get; set; }

        /// <summary>
        /// if this transaction is related to a Steem delegation, the delegation related to this exchange transaction
        /// </summary>
        /// <value>if this transaction is related to a Steem delegation, the delegation related to this exchange transaction</value>
        [DataMember(Name="delegationId")]
        public string DelegationId { get; set; }

        /// <summary>
        /// if this transaction is related to a Steem delegation, the amount of the delegation in VESTS
        /// </summary>
        /// <value>if this transaction is related to a Steem delegation, the amount of the delegation in VESTS</value>
        [DataMember(Name="vestsDelegated")]
        public string VestsDelegated { get; set; }

        /// <summary>
        /// if this transaction is related to a Steem Power delegation, the amount of the delegation in STEEM POWER at the time of the transaction
        /// </summary>
        /// <value>if this transaction is related to a Steem Power delegation, the amount of the delegation in STEEM POWER at the time of the transaction</value>
        [DataMember(Name="steemPowerDelegated")]
        public string SteemPowerDelegated { get; set; }

        /// <summary>
        /// if this transaction is related to a Steem Power delegation, the Steem account receiving the delegation
        /// </summary>
        /// <value>if this transaction is related to a Steem Power delegation, the Steem account receiving the delegation</value>
        [DataMember(Name="steemPowerDelegatee")]
        public string SteemPowerDelegatee { get; set; }

        /// <summary>
        /// if this transaction is a Steem Power delegation extension, the duration of the extension in seconds
        /// </summary>
        /// <value>if this transaction is a Steem Power delegation extension, the duration of the extension in seconds</value>
        [DataMember(Name="delegationExtensionDuration")]
        public string DelegationExtensionDuration { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransactionInfo {\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
            sb.Append("  TransactionProcessingState: ").Append(TransactionProcessingState).Append("\n");
            sb.Append("  InputFirstSeenTime: ").Append(InputFirstSeenTime).Append("\n");
            sb.Append("  InputFullyConfirmedTime: ").Append(InputFullyConfirmedTime).Append("\n");
            sb.Append("  InputNumberOfConfirmations: ").Append(InputNumberOfConfirmations).Append("\n");
            sb.Append("  InputAmount: ").Append(InputAmount).Append("\n");
            sb.Append("  InputTransactionHash: ").Append(InputTransactionHash).Append("\n");
            sb.Append("  InputCoinType: ").Append(InputCoinType).Append("\n");
            sb.Append("  InputWalletType: ").Append(InputWalletType).Append("\n");
            sb.Append("  InputAddress: ").Append(InputAddress).Append("\n");
            sb.Append("  PrimarySourceAddress: ").Append(PrimarySourceAddress).Append("\n");
            sb.Append("  OutputInitiationTime: ").Append(OutputInitiationTime).Append("\n");
            sb.Append("  OutputAmount: ").Append(OutputAmount).Append("\n");
            sb.Append("  OutputTransactionHash: ").Append(OutputTransactionHash).Append("\n");
            sb.Append("  OutputCoinType: ").Append(OutputCoinType).Append("\n");
            sb.Append("  OutputWalletType: ").Append(OutputWalletType).Append("\n");
            sb.Append("  OutputAddress: ").Append(OutputAddress).Append("\n");
            sb.Append("  OutputMemo: ").Append(OutputMemo).Append("\n");
            sb.Append("  OutputAddressNickname: ").Append(OutputAddressNickname).Append("\n");
            sb.Append("  LastModifiedTime: ").Append(LastModifiedTime).Append("\n");
            sb.Append("  RequiredNumberOfInputConfirmations: ").Append(RequiredNumberOfInputConfirmations).Append("\n");
            sb.Append("  InputUsdEquivalent: ").Append(InputUsdEquivalent).Append("\n");
            sb.Append("  DelegationId: ").Append(DelegationId).Append("\n");
            sb.Append("  VestsDelegated: ").Append(VestsDelegated).Append("\n");
            sb.Append("  SteemPowerDelegated: ").Append(SteemPowerDelegated).Append("\n");
            sb.Append("  SteemPowerDelegatee: ").Append(SteemPowerDelegatee).Append("\n");
            sb.Append("  DelegationExtensionDuration: ").Append(DelegationExtensionDuration).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((TransactionInfo)obj);
        }

        /// <summary>
        /// Returns true if TransactionInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of TransactionInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    TransactionId == other.TransactionId ||
                    TransactionId != null &&
                    TransactionId.Equals(other.TransactionId)
                ) && 
                (
                    TransactionProcessingState == other.TransactionProcessingState ||
                    TransactionProcessingState != null &&
                    TransactionProcessingState.Equals(other.TransactionProcessingState)
                ) && 
                (
                    InputFirstSeenTime == other.InputFirstSeenTime ||
                    InputFirstSeenTime != null &&
                    InputFirstSeenTime.Equals(other.InputFirstSeenTime)
                ) && 
                (
                    InputFullyConfirmedTime == other.InputFullyConfirmedTime ||
                    InputFullyConfirmedTime != null &&
                    InputFullyConfirmedTime.Equals(other.InputFullyConfirmedTime)
                ) && 
                (
                    InputNumberOfConfirmations == other.InputNumberOfConfirmations ||
                    InputNumberOfConfirmations != null &&
                    InputNumberOfConfirmations.Equals(other.InputNumberOfConfirmations)
                ) && 
                (
                    InputAmount == other.InputAmount ||
                    InputAmount != null &&
                    InputAmount.Equals(other.InputAmount)
                ) && 
                (
                    InputTransactionHash == other.InputTransactionHash ||
                    InputTransactionHash != null &&
                    InputTransactionHash.Equals(other.InputTransactionHash)
                ) && 
                (
                    InputCoinType == other.InputCoinType ||
                    InputCoinType != null &&
                    InputCoinType.Equals(other.InputCoinType)
                ) && 
                (
                    InputWalletType == other.InputWalletType ||
                    InputWalletType != null &&
                    InputWalletType.Equals(other.InputWalletType)
                ) && 
                (
                    InputAddress == other.InputAddress ||
                    InputAddress != null &&
                    InputAddress.Equals(other.InputAddress)
                ) && 
                (
                    PrimarySourceAddress == other.PrimarySourceAddress ||
                    PrimarySourceAddress != null &&
                    PrimarySourceAddress.Equals(other.PrimarySourceAddress)
                ) && 
                (
                    OutputInitiationTime == other.OutputInitiationTime ||
                    OutputInitiationTime != null &&
                    OutputInitiationTime.Equals(other.OutputInitiationTime)
                ) && 
                (
                    OutputAmount == other.OutputAmount ||
                    OutputAmount != null &&
                    OutputAmount.Equals(other.OutputAmount)
                ) && 
                (
                    OutputTransactionHash == other.OutputTransactionHash ||
                    OutputTransactionHash != null &&
                    OutputTransactionHash.Equals(other.OutputTransactionHash)
                ) && 
                (
                    OutputCoinType == other.OutputCoinType ||
                    OutputCoinType != null &&
                    OutputCoinType.Equals(other.OutputCoinType)
                ) && 
                (
                    OutputWalletType == other.OutputWalletType ||
                    OutputWalletType != null &&
                    OutputWalletType.Equals(other.OutputWalletType)
                ) && 
                (
                    OutputAddress == other.OutputAddress ||
                    OutputAddress != null &&
                    OutputAddress.Equals(other.OutputAddress)
                ) && 
                (
                    OutputMemo == other.OutputMemo ||
                    OutputMemo != null &&
                    OutputMemo.Equals(other.OutputMemo)
                ) && 
                (
                    OutputAddressNickname == other.OutputAddressNickname ||
                    OutputAddressNickname != null &&
                    OutputAddressNickname.Equals(other.OutputAddressNickname)
                ) && 
                (
                    LastModifiedTime == other.LastModifiedTime ||
                    LastModifiedTime != null &&
                    LastModifiedTime.Equals(other.LastModifiedTime)
                ) && 
                (
                    RequiredNumberOfInputConfirmations == other.RequiredNumberOfInputConfirmations ||
                    RequiredNumberOfInputConfirmations != null &&
                    RequiredNumberOfInputConfirmations.Equals(other.RequiredNumberOfInputConfirmations)
                ) && 
                (
                    InputUsdEquivalent == other.InputUsdEquivalent ||
                    InputUsdEquivalent != null &&
                    InputUsdEquivalent.Equals(other.InputUsdEquivalent)
                ) && 
                (
                    DelegationId == other.DelegationId ||
                    DelegationId != null &&
                    DelegationId.Equals(other.DelegationId)
                ) && 
                (
                    VestsDelegated == other.VestsDelegated ||
                    VestsDelegated != null &&
                    VestsDelegated.Equals(other.VestsDelegated)
                ) && 
                (
                    SteemPowerDelegated == other.SteemPowerDelegated ||
                    SteemPowerDelegated != null &&
                    SteemPowerDelegated.Equals(other.SteemPowerDelegated)
                ) && 
                (
                    SteemPowerDelegatee == other.SteemPowerDelegatee ||
                    SteemPowerDelegatee != null &&
                    SteemPowerDelegatee.Equals(other.SteemPowerDelegatee)
                ) && 
                (
                    DelegationExtensionDuration == other.DelegationExtensionDuration ||
                    DelegationExtensionDuration != null &&
                    DelegationExtensionDuration.Equals(other.DelegationExtensionDuration)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (TransactionId != null)
                    hashCode = hashCode * 59 + TransactionId.GetHashCode();
                    if (TransactionProcessingState != null)
                    hashCode = hashCode * 59 + TransactionProcessingState.GetHashCode();
                    if (InputFirstSeenTime != null)
                    hashCode = hashCode * 59 + InputFirstSeenTime.GetHashCode();
                    if (InputFullyConfirmedTime != null)
                    hashCode = hashCode * 59 + InputFullyConfirmedTime.GetHashCode();
                    if (InputNumberOfConfirmations != null)
                    hashCode = hashCode * 59 + InputNumberOfConfirmations.GetHashCode();
                    if (InputAmount != null)
                    hashCode = hashCode * 59 + InputAmount.GetHashCode();
                    if (InputTransactionHash != null)
                    hashCode = hashCode * 59 + InputTransactionHash.GetHashCode();
                    if (InputCoinType != null)
                    hashCode = hashCode * 59 + InputCoinType.GetHashCode();
                    if (InputWalletType != null)
                    hashCode = hashCode * 59 + InputWalletType.GetHashCode();
                    if (InputAddress != null)
                    hashCode = hashCode * 59 + InputAddress.GetHashCode();
                    if (PrimarySourceAddress != null)
                    hashCode = hashCode * 59 + PrimarySourceAddress.GetHashCode();
                    if (OutputInitiationTime != null)
                    hashCode = hashCode * 59 + OutputInitiationTime.GetHashCode();
                    if (OutputAmount != null)
                    hashCode = hashCode * 59 + OutputAmount.GetHashCode();
                    if (OutputTransactionHash != null)
                    hashCode = hashCode * 59 + OutputTransactionHash.GetHashCode();
                    if (OutputCoinType != null)
                    hashCode = hashCode * 59 + OutputCoinType.GetHashCode();
                    if (OutputWalletType != null)
                    hashCode = hashCode * 59 + OutputWalletType.GetHashCode();
                    if (OutputAddress != null)
                    hashCode = hashCode * 59 + OutputAddress.GetHashCode();
                    if (OutputMemo != null)
                    hashCode = hashCode * 59 + OutputMemo.GetHashCode();
                    if (OutputAddressNickname != null)
                    hashCode = hashCode * 59 + OutputAddressNickname.GetHashCode();
                    if (LastModifiedTime != null)
                    hashCode = hashCode * 59 + LastModifiedTime.GetHashCode();
                    if (RequiredNumberOfInputConfirmations != null)
                    hashCode = hashCode * 59 + RequiredNumberOfInputConfirmations.GetHashCode();
                    if (InputUsdEquivalent != null)
                    hashCode = hashCode * 59 + InputUsdEquivalent.GetHashCode();
                    if (DelegationId != null)
                    hashCode = hashCode * 59 + DelegationId.GetHashCode();
                    if (VestsDelegated != null)
                    hashCode = hashCode * 59 + VestsDelegated.GetHashCode();
                    if (SteemPowerDelegated != null)
                    hashCode = hashCode * 59 + SteemPowerDelegated.GetHashCode();
                    if (SteemPowerDelegatee != null)
                    hashCode = hashCode * 59 + SteemPowerDelegatee.GetHashCode();
                    if (DelegationExtensionDuration != null)
                    hashCode = hashCode * 59 + DelegationExtensionDuration.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(TransactionInfo left, TransactionInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TransactionInfo left, TransactionInfo right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}