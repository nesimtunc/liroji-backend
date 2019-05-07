using System;
using System.Runtime.Serialization;

namespace Business.Models
{
    public class BaseModel
    {
        public BaseModel()
        {

        }

        /// <summary>
        /// Model's unique identifier
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "created_by", EmitDefaultValue = true)]
        public String CreatedBy { get; set; }
    }
}
