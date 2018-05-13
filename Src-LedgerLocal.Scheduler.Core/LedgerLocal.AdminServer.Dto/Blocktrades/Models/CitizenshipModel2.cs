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
    /// CitizenshipModel2 Model
    /// </summary>
    [DataContract]
    public partial class CitizenshipModel2 : IEquatable<CitizenshipModel2>
    { 
        /// <summary>
        /// Gets or Sets CountryId
        /// </summary>
        [Required]
        [DataMember(Name="countryId")]
        public string CountryId { get; set; }

        /// <summary>
        /// Gets or Sets NewCountryId
        /// </summary>
        [Required]
        [DataMember(Name="newCountryId")]
        public string NewCountryId { get; set; }

        /// <summary>
        /// Gets or Sets IsPrimary
        /// </summary>
        [DataMember(Name="isPrimary")]
        public bool? IsPrimary { get; set; }

        /// <summary>
        /// the token identifying the session
        /// </summary>
        /// <value>the token identifying the session</value>
        [Required]
        [DataMember(Name="sessionToken")]
        public string SessionToken { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CitizenshipModel2 {\n");
            sb.Append("  CountryId: ").Append(CountryId).Append("\n");
            sb.Append("  NewCountryId: ").Append(NewCountryId).Append("\n");
            sb.Append("  IsPrimary: ").Append(IsPrimary).Append("\n");
            sb.Append("  SessionToken: ").Append(SessionToken).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CitizenshipModel2)obj);
        }

        /// <summary>
        /// Returns true if CitizenshipModel2 instances are equal
        /// </summary>
        /// <param name="other">Instance of CitizenshipModel2 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CitizenshipModel2 other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    CountryId == other.CountryId ||
                    CountryId != null &&
                    CountryId.Equals(other.CountryId)
                ) && 
                (
                    NewCountryId == other.NewCountryId ||
                    NewCountryId != null &&
                    NewCountryId.Equals(other.NewCountryId)
                ) && 
                (
                    IsPrimary == other.IsPrimary ||
                    IsPrimary != null &&
                    IsPrimary.Equals(other.IsPrimary)
                ) && 
                (
                    SessionToken == other.SessionToken ||
                    SessionToken != null &&
                    SessionToken.Equals(other.SessionToken)
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
                    if (CountryId != null)
                    hashCode = hashCode * 59 + CountryId.GetHashCode();
                    if (NewCountryId != null)
                    hashCode = hashCode * 59 + NewCountryId.GetHashCode();
                    if (IsPrimary != null)
                    hashCode = hashCode * 59 + IsPrimary.GetHashCode();
                    if (SessionToken != null)
                    hashCode = hashCode * 59 + SessionToken.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CitizenshipModel2 left, CitizenshipModel2 right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CitizenshipModel2 left, CitizenshipModel2 right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
