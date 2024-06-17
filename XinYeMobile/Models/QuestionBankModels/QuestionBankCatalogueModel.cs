using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XinYeMobile.Models.QuestionBankModels
{
    public class QuestionBankCatalogueModel
    {
        public string? Id { get; set; }
        /// <summary>
        /// 目录编号
        /// </summary>
        /// 
        [JsonPropertyName("catalogueId")]
        public int? CatalogueId { get; set; }
        /// <summary>
        /// 题目类型 章节练习   模拟卷  预测卷  历年真题卷等等
        /// </summary>
        /// 
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        /// <summary>
        /// 学科
        /// </summary>
        /// 
        [JsonPropertyName("discipline")]
        public string? Discipline { get; set; }
        /// <summary>
        /// 科目
        /// </summary>
        /// 
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }
        /// <summary>
        /// 目录标题 比如第一章
        /// </summary>
        /// 
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        /// <summary>
        /// 目录副标题  比如 会计概述
        /// </summary>
        /// 
        [JsonPropertyName("subtitle")]
        public string? Subtitle { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        /// 
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        /// <summary>
        /// 试卷编号
        /// </summary>
        /// 
        [JsonPropertyName("testPaperId")]
        public string? TestPaperId { get; set; }
        /// <summary>
        /// 总题目数
        /// </summary>
        /// 
        [JsonPropertyName("totalQuestion")]
        public long? TotalQuestion { get; set; }
        /// <summary>
        /// 已做题目数
        /// </summary>
        /// 
        [JsonPropertyName("completedCount")]
        public long? CompletedCount { get; set; }
        /// <summary>
        /// 已做人数
        /// </summary>
        /// 
        [JsonPropertyName("peopleCount")]
        public long? PeopleCount { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        /// 
        [JsonPropertyName("updateTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 难度等级
        /// </summary>
        /// 
        [JsonPropertyName("difficultyLevel")]
        public string? DifficultyLevel { get; set; }
        /// <summary>
        /// 上级目录的ID编号 如果为null  则当前为一级目录
        /// </summary>
        /// 
        [JsonPropertyName("parentId")]
        public string? ParentId { get; set; } = null;
        [JsonPropertyName("year")]
        public string? Year { get; set; }
        /// <summary>
        /// 子目录  请求时生成，不存储到数据库
        /// </summary>
        /// 
        [JsonPropertyName("items")]
        public List<QuestionBankCatalogueModel>? Items { get; set; } = new List<QuestionBankCatalogueModel> { };
        /// <summary>
        /// 指示是否展开
        /// </summary>
        public bool? IsExpanded { get; set; } = false;
    }

}
