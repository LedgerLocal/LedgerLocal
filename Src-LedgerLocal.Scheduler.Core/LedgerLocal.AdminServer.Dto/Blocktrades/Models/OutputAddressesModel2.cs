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
    /// OutputAddressesModel2 Model
    /// </summary>
    [DataContract]
    public partial class OutputAddressesModel2 : IEquatable<OutputAddressesModel2>
    { 
        /// <summary>
        /// the token identifying the session
        /// </summary>
        /// <value>the token identifying the session</value>
        [Required]
        [DataMember(Name="sessionToken")]
        public string SessionToken { get; set; }

        /// <summary>
        /// the nickname you want to change the old_nickname to
        /// </summary>
        /// <value>the nickname you want to change the old_nickname to</value>
        [Required]
        [DataMember(Name="newNickname")]
        public string NewNickname { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OutputAddressesModel2 {\n");
            sb.Append("  SessionToken: ").Append(SessionToken).Append("\n");
            sb.Append("  NewNickname: ").Append(NewNickname).Append("\n");
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
            return obj.GetType() == GetType() && Equals((OutputAddressesModel2)obj);
        }

        /// <summary>
        /// Returns true if OutputAddressesModel2 instances are equal
        /// </summary>
        /// <param name="other">Instance of OutputAddressesModel2 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OutputAddressesModel2 other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    SessionToken == other.SessionToken ||
                    SessionToken != null &&
                    SessionToken.Equals(other.SessionToken)
                ) && 
                (
                    NewNickname == other.NewNickname ||
                    NewNickname != null &&
                    NewNickname.Equals(other.NewNickname)
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
                    if (SessionToken != null)
                    hashCode = hashCode * 59 + SessionToken.GetHashCode();
                    if (NewNickname != null)
                    hashCode = hashCode * 59 + NewNickname.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(OutputAddressesModel2 left, OutputAddressesModel2 right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OutputAddressesModel2 left, OutputAddressesModel2 right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
