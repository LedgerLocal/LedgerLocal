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
    /// UserDetailsInfo Model
    /// </summary>
    [DataContract]
    public partial class UserDetailsInfo : IEquatable<UserDetailsInfo>
    { 
        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [Required]
        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [Required]
        [DataMember(Name="lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets DateOfBirth
        /// </summary>
        [Required]
        [DataMember(Name="dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or Sets PlaceOfBirth
        /// </summary>
        [Required]
        [DataMember(Name="placeOfBirth")]
        public string PlaceOfBirth { get; set; }

        /// <summary>
        /// Gets or Sets NationalIdNumber
        /// </summary>
        [Required]
        [DataMember(Name="nationalIdNumber")]
        public string NationalIdNumber { get; set; }

        /// <summary>
        /// Gets or Sets NationalIdType
        /// </summary>
        [Required]
        [DataMember(Name="nationalIdType")]
        public string NationalIdType { get; set; }

        /// <summary>
        /// Gets or Sets PrimaryCitizenshipId
        /// </summary>
        [Required]
        [DataMember(Name="primaryCitizenshipId")]
        public string PrimaryCitizenshipId { get; set; }

        /// <summary>
        /// Gets or Sets PrimaryAddressId
        /// </summary>
        [Required]
        [DataMember(Name="primaryAddressId")]
        public string PrimaryAddressId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserDetailsInfo {\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
            sb.Append("  PlaceOfBirth: ").Append(PlaceOfBirth).Append("\n");
            sb.Append("  NationalIdNumber: ").Append(NationalIdNumber).Append("\n");
            sb.Append("  NationalIdType: ").Append(NationalIdType).Append("\n");
            sb.Append("  PrimaryCitizenshipId: ").Append(PrimaryCitizenshipId).Append("\n");
            sb.Append("  PrimaryAddressId: ").Append(PrimaryAddressId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((UserDetailsInfo)obj);
        }

        /// <summary>
        /// Returns true if UserDetailsInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of UserDetailsInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserDetailsInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    FirstName == other.FirstName ||
                    FirstName != null &&
                    FirstName.Equals(other.FirstName)
                ) && 
                (
                    LastName == other.LastName ||
                    LastName != null &&
                    LastName.Equals(other.LastName)
                ) && 
                (
                    DateOfBirth == other.DateOfBirth ||
                    DateOfBirth != null &&
                    DateOfBirth.Equals(other.DateOfBirth)
                ) && 
                (
                    PlaceOfBirth == other.PlaceOfBirth ||
                    PlaceOfBirth != null &&
                    PlaceOfBirth.Equals(other.PlaceOfBirth)
                ) && 
                (
                    NationalIdNumber == other.NationalIdNumber ||
                    NationalIdNumber != null &&
                    NationalIdNumber.Equals(other.NationalIdNumber)
                ) && 
                (
                    NationalIdType == other.NationalIdType ||
                    NationalIdType != null &&
                    NationalIdType.Equals(other.NationalIdType)
                ) && 
                (
                    PrimaryCitizenshipId == other.PrimaryCitizenshipId ||
                    PrimaryCitizenshipId != null &&
                    PrimaryCitizenshipId.Equals(other.PrimaryCitizenshipId)
                ) && 
                (
                    PrimaryAddressId == other.PrimaryAddressId ||
                    PrimaryAddressId != null &&
                    PrimaryAddressId.Equals(other.PrimaryAddressId)
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
                    if (FirstName != null)
                    hashCode = hashCode * 59 + FirstName.GetHashCode();
                    if (LastName != null)
                    hashCode = hashCode * 59 + LastName.GetHashCode();
                    if (DateOfBirth != null)
                    hashCode = hashCode * 59 + DateOfBirth.GetHashCode();
                    if (PlaceOfBirth != null)
                    hashCode = hashCode * 59 + PlaceOfBirth.GetHashCode();
                    if (NationalIdNumber != null)
                    hashCode = hashCode * 59 + NationalIdNumber.GetHashCode();
                    if (NationalIdType != null)
                    hashCode = hashCode * 59 + NationalIdType.GetHashCode();
                    if (PrimaryCitizenshipId != null)
                    hashCode = hashCode * 59 + PrimaryCitizenshipId.GetHashCode();
                    if (PrimaryAddressId != null)
                    hashCode = hashCode * 59 + PrimaryAddressId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UserDetailsInfo left, UserDetailsInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserDetailsInfo left, UserDetailsInfo right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
