using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XinYeMobile.Models
{
    public class CollectModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("objectId")]
        public string? ObjectId {  get; set; }
        [JsonPropertyName("objectType")]
        public string? ObjectType {  get; set; }
        [JsonPropertyName("userId")]
        public string? UserId {  get; set; }
        [JsonPropertyName("submitTime")]
        public DateTime? SubmitTime { get; set; }
        [JsonPropertyName("iP")]
        public string? IP {  get; set; }
    }
}
