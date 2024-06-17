using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinYeMobile.Models.QuestionBankModels;

namespace XinYeMobile.Converters
{
    public class QuestionTypeToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value switch
            {
                QuestionType.Single => "单选题",
                QuestionType.Multiple => "多选题",
                QuestionType.Indefinite =>"不定项",
                QuestionType.Judge =>"判断题",
                QuestionType.Calculate =>"计算分析题",
                QuestionType.ShortAnswer =>"简答题",
                QuestionType.Comprehensive =>"综合分析题",
                QuestionType.Case =>"案例分析题",
                _ => "未知类型"
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
