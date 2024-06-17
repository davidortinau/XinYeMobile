using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinYeMobile.Models.QuestionBankModels;

namespace XinYeMobile.Converters
{
    public class IsNotSingleChoiceConverter:IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value switch
            {
                QuestionType.Single => false,
                QuestionType.Multiple => true,
                QuestionType.Indefinite => true,
                QuestionType.Judge => false,
                QuestionType.Calculate => true,
                QuestionType.ShortAnswer => true,
                QuestionType.Comprehensive => true,
                QuestionType.Case => true,
                _ => true
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
