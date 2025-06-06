/*
 * Tribufu API
 *
 * REST API to access Tribufu services.
 *
 * The version of the OpenAPI document: 1.1.0
 * Contact: contact@tribufu.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Tribufu.Generated.Client.OpenAPIDateConverter;

namespace Tribufu.Generated.Model
{
    /// <summary>
    /// Defines GroupRank
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupRank
    {
        /// <summary>
        /// Enum Member for value: member
        /// </summary>
        [EnumMember(Value = "member")]
        Member,

        /// <summary>
        /// Enum Leader for value: leader
        /// </summary>
        [EnumMember(Value = "leader")]
        Leader,

        /// <summary>
        /// Enum Owner for value: owner
        /// </summary>
        [EnumMember(Value = "owner")]
        Owner
    }

}
