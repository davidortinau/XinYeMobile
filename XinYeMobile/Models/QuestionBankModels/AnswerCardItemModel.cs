using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYeMobile.Models.QuestionBankModels
{
    public class AnswerCardItemModel
    {
        public int Index { get; set; }
        /// <summary>
        /// 做题状态  0 未做  1 部分已做  2 全做
        /// </summary>
        public int AnswerState { get; set; }
        /// <summary>
        /// 做题结果  0 未做  1 正确 2 错误 3 部分正确（主要是针对有多个小题的情况）
        /// </summary>
        public int ResultState { get; set; }
    }
}
