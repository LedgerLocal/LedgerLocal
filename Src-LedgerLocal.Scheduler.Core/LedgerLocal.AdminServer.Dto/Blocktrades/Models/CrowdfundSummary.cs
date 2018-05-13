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
    /// CrowdfundSummary Model
    /// </summary>
    [DataContract]
    public partial class CrowdfundSummary : IEquatable<CrowdfundSummary>
    { 
        /// <summary>
        /// a Javascript Object where the keys are the coin types, and the values are the amount of that coin type raised to date
        /// </summary>
        /// <value>a Javascript Object where the keys are the coin types, and the values are the amount of that coin type raised to date</value>
        [Required]
        [DataMember(Name="totalFundsRaised")]
        public string TotalFundsRaised { get; set; }

        /// <summary>
        /// the total amount raised to date, denominated in USD
        /// </summary>
        /// <value>the total amount raised to date, denominated in USD</value>
        [Required]
        [DataMember(Name="totalFundsRaisedInUsd")]
        public string TotalFundsRaisedInUsd { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrowdfundSummary {\n");
            sb.Append("  TotalFundsRaised: ").Append(TotalFundsRaised).Append("\n");
            sb.Append("  TotalFundsRaisedInUsd: ").Append(TotalFundsRaisedInUsd).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CrowdfundSummary)obj);
        }

        /// <summary>
        /// Returns true if CrowdfundSummary instances are equal
        /// </summary>
        /// <param name="other">Instance of CrowdfundSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CrowdfundSummary other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    TotalFundsRaised == other.TotalFundsRaised ||
                    TotalFundsRaised != null &&
                    TotalFundsRaised.Equals(other.TotalFundsRaised)
                ) && 
                (
                    TotalFundsRaisedInUsd == other.TotalFundsRaisedInUsd ||
                    TotalFundsRaisedInUsd != null &&
                    TotalFundsRaisedInUsd.Equals(other.TotalFundsRaisedInUsd)
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
                    if (TotalFundsRaised != null)
                    hashCode = hashCode * 59 + TotalFundsRaised.GetHashCode();
                    if (TotalFundsRaisedInUsd != null)
                    hashCode = hashCode * 59 + TotalFundsRaisedInUsd.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CrowdfundSummary left, CrowdfundSummary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CrowdfundSummary left, CrowdfundSummary right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
