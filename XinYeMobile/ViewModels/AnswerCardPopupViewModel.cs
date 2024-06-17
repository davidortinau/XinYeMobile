using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinYeMobile.Messages;
using XinYeMobile.Models.QuestionBankModels;

namespace XinYeMobile.ViewModels
{
    public partial class AnswerCardPopupViewModel:ObservableObject
    {
        [ObservableProperty]
        private List<AnswerCardItemModel> _answerList = new List<AnswerCardItemModel>();
        [ObservableProperty]
        private bool _isPracticeMode = true;//是否练习模式
        public AnswerCardPopupViewModel() 
        {
            
        }
        internal async Task UpdateViewModel(List<QuestionModel> questions,bool isPracticeModel)
        {
            try
            {
                int i = 1;
                IsPracticeMode = isPracticeModel;
                await Task.Run(() => 
                {
                    foreach(var Q in questions)
                    {
                        var answer = new AnswerCardItemModel();
                        answer.Index = i++;
                        answer.AnswerState = GetAnswerState(Q);
                        answer.ResultState = GetResultState(Q);
                        AnswerList.Add(answer);
                    }
                });
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 获取答题状态  
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        private int GetAnswerState(QuestionModel question)
        {
            try
            {
                var answerCount = 0;
                foreach (var q in question.Questions)
                {
                    if (!string.IsNullOrEmpty(q.MyAnswer))
                    {
                        answerCount++;
                    }
                }
                if (answerCount == 0)
                {
                    //未做
                    return 0;
                }
                else if (answerCount < question.Questions.Count())
                {
                    //部分已做
                    return 1;
                }
                else
                {
                    //全做
                    return 2;
                }
            }
            catch
            {
                return 0;
            }

        }
        /// <summary>
        /// 获取答题结果状态  做题结果  0 未做  1 正确 2 错误 3 部分正确（主要是针对有多个小题的情况）
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        private int GetResultState(QuestionModel question)
        {
            try
            {
                var answerCount = 0;//已做题目量
                var correctCount = 0;//正确题目量
                var errorCount = 0;//错误题目量
                foreach (var q in question.Questions)
                {
                    if (!string.IsNullOrEmpty(q.MyAnswer))
                    {
                        answerCount++;
                        if (q.MyAnswer == q.Answer)
                        {
                            correctCount++;
                        }
                        else
                        {
                            errorCount++;
                        }
                    }
                }
                if (answerCount == 0)
                {
                    //未做
                    return 0;
                }
                else
                {
                    if (correctCount == question.Questions.Count())
                    {
                        //全对
                        return 1;
                    }
                    else if (errorCount == question.Questions.Count())
                    {
                        //全错
                        return 2;
                    }
                    else
                    {
                        //部分正确
                        return 3;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        [RelayCommand]
        private async Task Tap(int index)
        {
            try
            {
                WeakReferenceMessenger.Default.Send(new CurrentQuestionChangedMessage(index-1));
            }
            catch
            {

            }
        }
    }
}
