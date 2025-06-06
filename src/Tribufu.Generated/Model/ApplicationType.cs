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
    /// Defines ApplicationType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApplicationType
    {
        /// <summary>
        /// Enum Application for value: application
        /// </summary>
        [EnumMember(Value = "application")]
        Application,

        /// <summary>
        /// Enum Game for value: game
        /// </summary>
        [EnumMember(Value = "game")]
        Game
    }

}
