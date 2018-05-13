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
    /// SimpleFixedPriceTradeInfo Model
    /// </summary>
    [DataContract]
    public partial class SimpleFixedPriceTradeInfo : IEquatable<SimpleFixedPriceTradeInfo>
    { 
        /// <summary>
        /// the input address where the user should send the funds to convert. The format will vary depending on the input wallet type
        /// </summary>
        /// <value>the input address where the user should send the funds to convert. The format will vary depending on the input wallet type</value>
        [Required]
        [DataMember(Name="inputAddress")]
        public string InputAddress { get; set; }

        /// <summary>
        /// the coin type which is sent in to BlockTrades
        /// </summary>
        /// <value>the coin type which is sent in to BlockTrades</value>
        [Required]
        [DataMember(Name="inputCoinType")]
        public string InputCoinType { get; set; }

        /// <summary>
        /// the amount the user should send in order to receive the exact amount they requested
        /// </summary>
        /// <value>the amount the user should send in order to receive the exact amount they requested</value>
        [Required]
        [DataMember(Name="inputAmount")]
        public string InputAmount { get; set; }

        /// <summary>
        /// the output address where BlockTrades will send the results of this conversion
        /// </summary>
        /// <value>the output address where BlockTrades will send the results of this conversion</value>
        [Required]
        [DataMember(Name="outputAddress")]
        public string OutputAddress { get; set; }

        /// <summary>
        /// the type of output coin BlockTrades will generate
        /// </summary>
        /// <value>the type of output coin BlockTrades will generate</value>
        [Required]
        [DataMember(Name="outputCoinType")]
        public string OutputCoinType { get; set; }

        /// <summary>
        /// the amount the user will receive
        /// </summary>
        /// <value>the amount the user will receive</value>
        [Required]
        [DataMember(Name="outputAmount")]
        public string OutputAmount { get; set; }

        /// <summary>
        /// the refund address where BlockTrades will send any funds it was unable to convert (null if none was suppied)
        /// </summary>
        /// <value>the refund address where BlockTrades will send any funds it was unable to convert (null if none was suppied)</value>
        [Required]
        [DataMember(Name="refundAddress")]
        public string RefundAddress { get; set; }

        /// <summary>
        /// The time this fixed-price trade is valid until.
        /// </summary>
        /// <value>The time this fixed-price trade is valid until.</value>
        [Required]
        [DataMember(Name="expirationTime")]
        public string ExpirationTime { get; set; }

        /// <summary>
        /// output transaction fee converted to input coin type.
        /// </summary>
        /// <value>output transaction fee converted to input coin type.</value>
        [Required]
        [DataMember(Name="flatTransactionFeeInInputCoinType")]
        public double? FlatTransactionFeeInInputCoinType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SimpleFixedPriceTradeInfo {\n");
            sb.Append("  InputAddress: ").Append(InputAddress).Append("\n");
            sb.Append("  InputCoinType: ").Append(InputCoinType).Append("\n");
            sb.Append("  InputAmount: ").Append(InputAmount).Append("\n");
            sb.Append("  OutputAddress: ").Append(OutputAddress).Append("\n");
            sb.Append("  OutputCoinType: ").Append(OutputCoinType).Append("\n");
            sb.Append("  OutputAmount: ").Append(OutputAmount).Append("\n");
            sb.Append("  RefundAddress: ").Append(RefundAddress).Append("\n");
            sb.Append("  ExpirationTime: ").Append(ExpirationTime).Append("\n");
            sb.Append("  FlatTransactionFeeInInputCoinType: ").Append(FlatTransactionFeeInInputCoinType).Append("\n");
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
            return obj.GetType() == GetType() && Equals((SimpleFixedPriceTradeInfo)obj);
        }

        /// <summary>
        /// Returns true if SimpleFixedPriceTradeInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of SimpleFixedPriceTradeInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimpleFixedPriceTradeInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    InputAddress == other.InputAddress ||
                    InputAddress != null &&
                    InputAddress.Equals(other.InputAddress)
                ) && 
                (
                    InputCoinType == other.InputCoinType ||
                    InputCoinType != null &&
                    InputCoinType.Equals(other.InputCoinType)
                ) && 
                (
                    InputAmount == other.InputAmount ||
                    InputAmount != null &&
                    InputAmount.Equals(other.InputAmount)
                ) && 
                (
                    OutputAddress == other.OutputAddress ||
                    OutputAddress != null &&
                    OutputAddress.Equals(other.OutputAddress)
                ) && 
                (
                    OutputCoinType == other.OutputCoinType ||
                    OutputCoinType != null &&
                    OutputCoinType.Equals(other.OutputCoinType)
                ) && 
                (
                    OutputAmount == other.OutputAmount ||
                    OutputAmount != null &&
                    OutputAmount.Equals(other.OutputAmount)
                ) && 
                (
                    RefundAddress == other.RefundAddress ||
                    RefundAddress != null &&
                    RefundAddress.Equals(other.RefundAddress)
                ) && 
                (
                    ExpirationTime == other.ExpirationTime ||
                    ExpirationTime != null &&
                    ExpirationTime.Equals(other.ExpirationTime)
                ) && 
                (
                    FlatTransactionFeeInInputCoinType == other.FlatTransactionFeeInInputCoinType ||
                    FlatTransactionFeeInInputCoinType != null &&
                    FlatTransactionFeeInInputCoinType.Equals(other.FlatTransactionFeeInInputCoinType)
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
                    if (InputAddress != null)
                    hashCode = hashCode * 59 + InputAddress.GetHashCode();
                    if (InputCoinType != null)
                    hashCode = hashCode * 59 + InputCoinType.GetHashCode();
                    if (InputAmount != null)
                    hashCode = hashCode * 59 + InputAmount.GetHashCode();
                    if (OutputAddress != null)
                    hashCode = hashCode * 59 + OutputAddress.GetHashCode();
                    if (OutputCoinType != null)
                    hashCode = hashCode * 59 + OutputCoinType.GetHashCode();
                    if (OutputAmount != null)
                    hashCode = hashCode * 59 + OutputAmount.GetHashCode();
                    if (RefundAddress != null)
                    hashCode = hashCode * 59 + RefundAddress.GetHashCode();
                    if (ExpirationTime != null)
                    hashCode = hashCode * 59 + ExpirationTime.GetHashCode();
                    if (FlatTransactionFeeInInputCoinType != null)
                    hashCode = hashCode * 59 + FlatTransactionFeeInInputCoinType.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(SimpleFixedPriceTradeInfo left, SimpleFixedPriceTradeInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SimpleFixedPriceTradeInfo left, SimpleFixedPriceTradeInfo right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}