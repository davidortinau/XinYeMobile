using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XinYeMobile.Models
{
    public class ResponseModel
    {

    }

    public class SmsCodeResponse
    {
        public string? Msg { get; set; }
        public int? ExpireTime {  get; set; }
    }

    public abstract class Response
    {
        public string Msg { get; set; } = string.Empty;
    }
    /// <summary>
    /// 错误响应
    /// </summary>
    public class ErrorResponse : Response
    {
        public int? ErrCode { get; set; }
    }
    /// <summary>
    /// 查询数据分页信息
    /// </summary>
    public class Pager
    {
        /// <summary>
        /// 查询到的总数据
        /// </summary>
        /// 
        [JsonPropertyName("total")]
        public long Total { get; set; } = 0;
        /// <summary>
        /// 单次查询限制
        /// </summary>
        /// 
        [JsonPropertyName("limit")]
        public long Limit { get; set; } = 0;
        /// <summary>
        /// 查询偏移量
        /// </summary>
        /// 
        [JsonPropertyName("offset")]
        public long Offset { get; set; } = 0;
    }
    public class QueryResponse<T> : Response
    {
        [JsonPropertyName("pager")]
        public Pager? Pager { get; set; }
        [JsonPropertyName("data")]
        public List<T>? Data { get; set; } = new List<T>();
    }
}
