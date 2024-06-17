using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XinYeMobile.Models.QuestionBankModels
{
    public class QuestionModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        /// <summary>
        /// 题目编号 唯一值
        /// </summary>
        /// 
        [JsonPropertyName("questionId")]
        public string? QuestionId { get; set; }
        /// <summary>
        /// 背景材料
        /// </summary>
        /// 
        [JsonPropertyName("description")]
        public string? Description { get; set; } = null;
        /// <summary>
        /// 题目类型  单选 多选 判断 不定项等
        /// </summary>
        ///
        [JsonPropertyName("questionType")]
        public QuestionType? QuestionType { get; set; }
        /// <summary>
        /// 所属学科
        /// </summary>
        /// 
        [JsonPropertyName("discipline")]
        public string? Discipline { get; set; }
        /// <summary>
        /// 所属科目
        /// </summary>
        /// 
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }
        /// <summary>
        /// 主分组
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        /// <summary>
        /// 次分组
        /// </summary>
        [JsonPropertyName("subTitle")]
        public string? SubTitle { get; set; }

        /// <summary>
        /// 小题 每个大题可能包含若干个小题
        /// </summary>
        [JsonPropertyName("questions")]
        public List<QuestionItem>? Questions { get; set; } = new List<QuestionItem>();
        /// <summary>
        /// 创建时间
        /// </summary>
        /// 
        [JsonPropertyName("createdTime")]
        public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// 题目所属年份
        /// </summary>
        /// 
        [JsonPropertyName("year")]
        public string? Year { get; set; }

        private bool isCollect = false;
        /// <summary>
        /// 是否已收藏
        /// </summary>
        public bool IsCollect
        {
            get => isCollect; set
            {
                if (isCollect != value)
                {
                    isCollect = value;
                    OnPropertyChanged(nameof(isCollect));
                }
            }
        }
        // INotifyPropertyChanged 实现
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum QuestionType
    {
        /// <summary>
        /// 单选
        /// </summary>
        Single,
        /// <summary>
        /// 多选
        /// </summary>
        Multiple,
        /// <summary>
        /// 判断
        /// </summary>
        Judge,
        /// <summary>
        /// 不定项
        /// </summary>
        Indefinite,
        /// <summary>
        /// 计算分析题
        /// </summary>
        Calculate,
        /// <summary>
        /// 简答分析题
        /// </summary>
        ShortAnswer,
        /// <summary>
        /// 综合分析题
        /// </summary>
        Comprehensive,
        /// <summary>
        /// 案例分析题
        /// </summary>
        Case
    }

    /// <summary>
    /// 选项类
    /// </summary>
    public class ChoiceItem:INotifyPropertyChanged
    {
        /// <summary>
        /// 选项ABCD
        /// </summary>
        /// 
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        /// <summary>
        /// 选项内容
        /// </summary>
        /// 
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        public bool IsAnswer { get; set; } = false;
        /// <summary>
        /// 是否选择 题目本身在数据库中不保存该值
        /// </summary>
        private bool isChecked = false;

        /// <summary>
        /// 是否选择 题目本身在数据库中不保存该值
        /// </summary>
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    OnPropertyChanged();
                }
            }
        }
        // INotifyPropertyChanged 实现
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    /// <summary>
    /// 小题类
    /// </summary>
    public class QuestionItem: INotifyPropertyChanged
    {
        /// <summary>
        /// 问题
        /// </summary>
        /// 
        [JsonPropertyName("question")]
        public string? Question { get; set; }
        [JsonPropertyName("choices")]
        public List<ChoiceItem>? Choices { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        /// 
        [JsonPropertyName("answer")]
        public string? Answer { get; set; }
        /// <summary>
        /// 解析
        /// </summary>
        /// 
        [JsonPropertyName("analysis")]
        public string? Analysis { get; set; }
        /// <summary>
        /// 视频链接 用于视频讲解
        /// </summary>
        /// 
        [JsonPropertyName("video")]
        public string? Video { get; set; }

        /// <summary>
        /// 答题状态 全对  半对 错误  未作答  一共四种
        /// </summary>
        public string? AnswerState { get; set; } = "未作答";
        /// <summary>
        /// 本题用时   单位s 精度小数点后1位
        /// </summary>
        public decimal? Duration { get; set; }
        /// <summary>
        /// 作答次数
        /// </summary>
        public int? AnswerCount { get; set; } = 0;
        /// <summary>
        /// 作答正确次数
        /// </summary>
        public int? CorrectCount { get; set; } = 0;
        /// <summary>
        /// 作答错误次数
        /// </summary>
        public int? ErrorCount {  get; set; } = 0;

        private bool isShowAnswer = false;
        private bool isChoiced = false;
        private string? myAnswer = null;

        /// <summary>
        /// 学员答案
        /// </summary>
        public string? MyAnswer { get => myAnswer; set 
            {
                if(myAnswer != value)
                {
                    myAnswer = value;
                    OnPropertyChanged(nameof(MyAnswer));
                }
            } }
        /// <summary>
        /// 只是当前题目是否有题目被选中
        /// </summary>
        public bool IsChoiced
        {
            get => isChoiced;
            set
            {
                if (isChoiced != value)
                {
                    isChoiced = value;
                    OnPropertyChanged(nameof(IsChoiced));
                }
            }
        }
        /// <summary>
        /// 是否显示当前的做题结果
        /// </summary>
        public bool IsShowAnswer
        {
            get => isShowAnswer;
            set
            {
                if (isShowAnswer != value)
                {
                    isShowAnswer = value;
                    OnPropertyChanged(nameof(IsShowAnswer));
                }
            }
        }
        // INotifyPropertyChanged 实现
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
