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
    /// Subscription
    /// </summary>
    [DataContract(Name = "Subscription")]
    public partial class Subscription : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="imageUrl">imageUrl.</param>
        /// <param name="created">created.</param>
        /// <param name="updated">updated.</param>
        public Subscription(string id = default(string), string name = default(string), string description = default(string), string imageUrl = default(string), DateTime created = default(DateTime), DateTime? updated = default(DateTime?))
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.Created = created;
            this.Updated = updated;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ImageUrl
        /// </summary>
        [DataMember(Name = "image_url", EmitDefaultValue = true)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or Sets Prices
        /// </summary>
        [DataMember(Name = "prices", EmitDefaultValue = true)]
        public Dictionary<string, double> Prices { get; private set; }

        /// <summary>
        /// Returns false as Prices should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePrices()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets Updated
        /// </summary>
        [DataMember(Name = "updated", EmitDefaultValue = true)]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Subscription {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
            sb.Append("  Prices: ").Append(Prices).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 75)
            {
                yield return new ValidationResult("Invalid value for Name, length must be less than 75.", new [] { "Name" });
            }

            // ImageUrl (string) maxLength
            if (this.ImageUrl != null && this.ImageUrl.Length > 255)
            {
                yield return new ValidationResult("Invalid value for ImageUrl, length must be less than 255.", new [] { "ImageUrl" });
            }

            yield break;
        }
    }

}
