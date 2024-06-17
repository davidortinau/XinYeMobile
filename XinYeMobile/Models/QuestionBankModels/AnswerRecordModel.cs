using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XinYeMobile.Models.QuestionBankModels
{
    public class AnswerRecordModel
    {
        public string? UserId { get; set; }
        /// <summary>
        /// 测试卷ID  所有的题  均需有一个试卷ID用来进行组卷
        /// </summary>
        [JsonPropertyName("testPaperId")]
        public string? TestPaperId { get; set; }
        /// <summary>
        /// 题目id
        /// </summary>
        [JsonPropertyName("questionId")]
        public string? QuestionId { get; set; }
        /// <summary>
        /// 题目子编号 0 1 2 3 4 5
        /// </summary>
        [JsonPropertyName("subId")]
        public int SubId { get; set; }

        /// <summary>
        /// 用户答案 可以是选择题 也可以是文字答案
        /// </summary>
        [JsonPropertyName("myAnswer")]
        public string? MyAnswer { get; set; }
        /// <summary>
        /// 做题总用时  ms单位
        /// </summary>
        /// 
        [JsonPropertyName("totalTime")]
        public double TotalTime { get; set; } = 0;

        /// <summary>
        /// 清楚做题记录的时间
        /// </summary>
        /// 
        [JsonPropertyName("clearTime")]
        public DateTime? ClearTime { get; set; } = null;
        /// <summary>
        /// 所属年份
        /// </summary>
        /// 
        [JsonPropertyName("year")]
        public string? Year { get; set; }
    }
}
