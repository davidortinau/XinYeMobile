using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XinYeMobile.Models
{
    public class CommentModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        /// <summary>
        /// 评论的对象ID 比如题目ID  页面ID  活动ID 等等
        /// </summary>
        /// 
        [JsonPropertyName("objectId")]
        public string? ObjectId { get; set; }
        /// <summary>
        /// 评论的父ID 如果为空或null 则表示当前是父级评论  不为空  则为子级评论
        /// </summary>
        [JsonPropertyName("parentId")]
        public string? ParentId { get; set; }
        /// <summary>
        /// 回复的评论对象ID  如果为空或null  则为回复父评论
        /// </summary>
        [JsonPropertyName("replyId")]
        public string? ReplyId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [JsonPropertyName("content")]
        public string? Content { get; set; }
        [JsonPropertyName("userId")]
        public string? UserId { get; set; }
        /// <summary>
        /// 评论提交时间
        /// </summary>
        /// 
        [JsonPropertyName("submitTime")]
        public DateTime? SubmitTime { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("isSetTop")]
        public bool IsSetTop { get; set; } = false;
        /// <summary>
        /// 点赞量
        /// </summary>
        /// 
        [JsonPropertyName("likeCount")]
        public int LikeCount { get; set; } = 0;
        /// <summary>
        /// 讨厌量
        /// </summary>
        /// 
        [JsonPropertyName("unLikeCount")]
        public int UnLikeCount { get; set; } = 0;
        /// <summary>
        /// IP地址
        /// </summary>
        /// 
        [JsonPropertyName("iP")]
        public string? IP { get; set; }
        /// <summary>
        /// 子评论集合
        /// </summary>
        public ObservableCollection<CommentModel> Children { get; set; } = new ObservableCollection<CommentModel>();
    }
}
