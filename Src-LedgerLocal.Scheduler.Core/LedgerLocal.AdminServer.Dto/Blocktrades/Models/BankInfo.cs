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
    /// BankInfo Model
    /// </summary>
    [DataContract]
    public partial class BankInfo : IEquatable<BankInfo>
    { 
        /// <summary>
        /// name of the address - unique in user scope
        /// </summary>
        /// <value>name of the address - unique in user scope</value>
        [Required]
        [DataMember(Name="nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// id of currency
        /// </summary>
        /// <value>id of currency</value>
        [Required]
        [DataMember(Name="currencyId")]
        public string CurrencyId { get; set; }

        /// <summary>
        /// the recipient&#39;s full name
        /// </summary>
        /// <value>the recipient&#39;s full name</value>
        [Required]
        [DataMember(Name="accountHolder")]
        public string AccountHolder { get; set; }

        /// <summary>
        /// the recipient&#39;s bank account number
        /// </summary>
        /// <value>the recipient&#39;s bank account number</value>
        [Required]
        [DataMember(Name="accountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// the International Bank Account Number
        /// </summary>
        /// <value>the International Bank Account Number</value>
        [Required]
        [DataMember(Name="iban")]
        public string Iban { get; set; }

        /// <summary>
        /// the name of the bank where the recipient&#39;s account is held
        /// </summary>
        /// <value>the name of the bank where the recipient&#39;s account is held</value>
        [Required]
        [DataMember(Name="bankName")]
        public string BankName { get; set; }

        /// <summary>
        /// UK bank code (6 digits usually displayed as 3 pairs of numbers)
        /// </summary>
        /// <value>UK bank code (6 digits usually displayed as 3 pairs of numbers)</value>
        [Required]
        [DataMember(Name="sortCode")]
        public string SortCode { get; set; }

        /// <summary>
        /// the American Bankers Association number (consists of 9 digits) and is also called a ABA routing number
        /// </summary>
        /// <value>the American Bankers Association number (consists of 9 digits) and is also called a ABA routing number</value>
        [Required]
        [DataMember(Name="routingNumber")]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// a SWIFT code consists of 8 or 11 characters, both numbers and letters e.g. RFXLGB2L
        /// </summary>
        /// <value>a SWIFT code consists of 8 or 11 characters, both numbers and letters e.g. RFXLGB2L</value>
        [Required]
        [DataMember(Name="swiftBic")]
        public string SwiftBic { get; set; }

        /// <summary>
        /// Indian Financial System Code, which is a unique 11-digit code that identifies the bank branch i.e. ICIC0001245
        /// </summary>
        /// <value>Indian Financial System Code, which is a unique 11-digit code that identifies the bank branch i.e. ICIC0001245</value>
        [Required]
        [DataMember(Name="ifscCode")]
        public string IfscCode { get; set; }

        /// <summary>
        /// any other local bank code - eg BSB number in Australia and New Zealand (6 digits)
        /// </summary>
        /// <value>any other local bank code - eg BSB number in Australia and New Zealand (6 digits)</value>
        [Required]
        [DataMember(Name="routingCode")]
        public string RoutingCode { get; set; }

        /// <summary>
        /// id of user address
        /// </summary>
        /// <value>id of user address</value>
        [Required]
        [DataMember(Name="userAddressId")]
        public string UserAddressId { get; set; }

        /// <summary>
        /// info about bank address
        /// </summary>
        /// <value>info about bank address</value>
        [Required]
        [DataMember(Name="bankAddress")]
        public PhysicalAddress BankAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BankInfo {\n");
            sb.Append("  Nickname: ").Append(Nickname).Append("\n");
            sb.Append("  CurrencyId: ").Append(CurrencyId).Append("\n");
            sb.Append("  AccountHolder: ").Append(AccountHolder).Append("\n");
            sb.Append("  AccountNumber: ").Append(AccountNumber).Append("\n");
            sb.Append("  Iban: ").Append(Iban).Append("\n");
            sb.Append("  BankName: ").Append(BankName).Append("\n");
            sb.Append("  SortCode: ").Append(SortCode).Append("\n");
            sb.Append("  RoutingNumber: ").Append(RoutingNumber).Append("\n");
            sb.Append("  SwiftBic: ").Append(SwiftBic).Append("\n");
            sb.Append("  IfscCode: ").Append(IfscCode).Append("\n");
            sb.Append("  RoutingCode: ").Append(RoutingCode).Append("\n");
            sb.Append("  UserAddressId: ").Append(UserAddressId).Append("\n");
            sb.Append("  BankAddress: ").Append(BankAddress).Append("\n");
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
            return obj.GetType() == GetType() && Equals((BankInfo)obj);
        }

        /// <summary>
        /// Returns true if BankInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of BankInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BankInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Nickname == other.Nickname ||
                    Nickname != null &&
                    Nickname.Equals(other.Nickname)
                ) && 
                (
                    CurrencyId == other.CurrencyId ||
                    CurrencyId != null &&
                    CurrencyId.Equals(other.CurrencyId)
                ) && 
                (
                    AccountHolder == other.AccountHolder ||
                    AccountHolder != null &&
                    AccountHolder.Equals(other.AccountHolder)
                ) && 
                (
                    AccountNumber == other.AccountNumber ||
                    AccountNumber != null &&
                    AccountNumber.Equals(other.AccountNumber)
                ) && 
                (
                    Iban == other.Iban ||
                    Iban != null &&
                    Iban.Equals(other.Iban)
                ) && 
                (
                    BankName == other.BankName ||
                    BankName != null &&
                    BankName.Equals(other.BankName)
                ) && 
                (
                    SortCode == other.SortCode ||
                    SortCode != null &&
                    SortCode.Equals(other.SortCode)
                ) && 
                (
                    RoutingNumber == other.RoutingNumber ||
                    RoutingNumber != null &&
                    RoutingNumber.Equals(other.RoutingNumber)
                ) && 
                (
                    SwiftBic == other.SwiftBic ||
                    SwiftBic != null &&
                    SwiftBic.Equals(other.SwiftBic)
                ) && 
                (
                    IfscCode == other.IfscCode ||
                    IfscCode != null &&
                    IfscCode.Equals(other.IfscCode)
                ) && 
                (
                    RoutingCode == other.RoutingCode ||
                    RoutingCode != null &&
                    RoutingCode.Equals(other.RoutingCode)
                ) && 
                (
                    UserAddressId == other.UserAddressId ||
                    UserAddressId != null &&
                    UserAddressId.Equals(other.UserAddressId)
                ) && 
                (
                    BankAddress == other.BankAddress ||
                    BankAddress != null &&
                    BankAddress.Equals(other.BankAddress)
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
                    if (Nickname != null)
                    hashCode = hashCode * 59 + Nickname.GetHashCode();
                    if (CurrencyId != null)
                    hashCode = hashCode * 59 + CurrencyId.GetHashCode();
                    if (AccountHolder != null)
                    hashCode = hashCode * 59 + AccountHolder.GetHashCode();
                    if (AccountNumber != null)
                    hashCode = hashCode * 59 + AccountNumber.GetHashCode();
                    if (Iban != null)
                    hashCode = hashCode * 59 + Iban.GetHashCode();
                    if (BankName != null)
                    hashCode = hashCode * 59 + BankName.GetHashCode();
                    if (SortCode != null)
                    hashCode = hashCode * 59 + SortCode.GetHashCode();
                    if (RoutingNumber != null)
                    hashCode = hashCode * 59 + RoutingNumber.GetHashCode();
                    if (SwiftBic != null)
                    hashCode = hashCode * 59 + SwiftBic.GetHashCode();
                    if (IfscCode != null)
                    hashCode = hashCode * 59 + IfscCode.GetHashCode();
                    if (RoutingCode != null)
                    hashCode = hashCode * 59 + RoutingCode.GetHashCode();
                    if (UserAddressId != null)
                    hashCode = hashCode * 59 + UserAddressId.GetHashCode();
                    if (BankAddress != null)
                    hashCode = hashCode * 59 + BankAddress.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(BankInfo left, BankInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BankInfo left, BankInfo right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
