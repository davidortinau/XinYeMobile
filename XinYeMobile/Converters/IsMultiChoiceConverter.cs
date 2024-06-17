using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinYeMobile.Models.QuestionBankModels;

namespace XinYeMobile.Converters
{
    public class IsMultiChoiceConverter:IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value switch
            {
                QuestionType.Single => false,
                QuestionType.Multiple => true,
                QuestionType.Indefinite => true,
                QuestionType.Judge => false,
                QuestionType.Calculate => false,
                QuestionType.ShortAnswer => false,
                QuestionType.Comprehensive => false,
                QuestionType.Case => false,
                _ => false
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
