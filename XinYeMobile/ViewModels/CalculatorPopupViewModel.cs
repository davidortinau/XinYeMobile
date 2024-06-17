using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using org.matheval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace XinYeMobile.ViewModels
{

    public partial class CalculatorPopupViewModel:ObservableObject
    {
        private List<string> numbers = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private List<string> operators = new List<string> { "+", "-", "×", "÷" };
        private bool isComplete = false;
        [ObservableProperty]
        private string _result = "0";
        [ObservableProperty]
        private string _expression = string.Empty;


        private bool _isOldEntry = false;
        string a = "0";
        string b = string.Empty;
        string o = string.Empty;


        public CalculatorPopupViewModel() 
        {
            
        }


        [RelayCommand]
        public async Task Click(string ch)
        {
            try
            {
                string R_last = Result.Length > 0 ? Result[Result.Length - 1].ToString() : string.Empty;
                string E_last = Expression.Length>0 ? Expression[Expression.Length -1].ToString() : string.Empty;
                if ("=" ==  ch)
                {
                    //等于号
                    if (string.IsNullOrEmpty(Expression))
                    {
                        Expression = a + "=";
                        Result = a;
                        _isOldEntry = true;
                    }
                    else if (Expression == (a + o))
                    {
                        b = Result;
                        Expression = a + o + b;
                        try
                        {
                            var res = new Expression(Expression.Replace("÷", "/").Replace("×", "*")).Eval();
                            Expression += "=";
                            Result = res.ToString()??"0";
                            _isOldEntry = true;
                        }
                        catch
                        {
                            a = "0";
                            b = string.Empty;
                            o = string.Empty;
                            Result = "表达式错误";
                            Expression = string.Empty;
                            _isOldEntry = false;
                        }
                    }
                    else if (Expression == (a+o+b+"="))
                    {
                        a = Result;
                        Expression = a + o + b;
                        try
                        {
                            var res = new Expression(Expression.Replace("÷", "/").Replace("×", "*")).Eval();
                            Result = res.ToString()??"0";
                            Expression += "=";
                            _isOldEntry = true;
                        }
                        catch
                        {
                            a = "0";
                            b = string.Empty;
                            o = string.Empty;
                            Result = "表达式错误";
                            Expression = string.Empty;
                            _isOldEntry = false;
                        }
                    }
                }
                else if (operators.Contains(ch))
                {
                    //运算符
                    if (string.IsNullOrEmpty(Expression))
                    {
                        a = Convert.ToDecimal(a).ToString();
                        o = ch;
                        _isOldEntry =true;
                        Expression = a + o;
                    }
                    else if (Expression == (a+"="))
                    {
                        o = ch;
                        _isOldEntry =true;
                        Expression = a + o;
                    }
                    else if (Expression == (a + o)&&!string.IsNullOrEmpty(o))
                    {
                        if (_isOldEntry)
                        {
                            o = ch;
                            Expression = a + o;
                        }
                        else
                        {
                            try
                            {
                                Expression += Result;
                                b = Result;
                                var res = new Expression(Expression.Replace("÷", "/").Replace("×", "*")).Eval();
                                Expression = res + ch;
                                o = ch;
                                a = res.ToString()??"0";
                                Result = a;
                                _isOldEntry = true;
                            }
                            catch
                            {
                                a = "0";
                                b = string.Empty;
                                o = string.Empty;
                                Result = "表达式错误";
                                Expression = string.Empty;
                                _isOldEntry = false;
                            }
                        }
                    }
                    else if (Expression == (a + o +b+ "=")&&(!string.IsNullOrEmpty(o))&&(!string.IsNullOrEmpty(b)))
                    {
                        a = Result;
                        o = ch;
                        Expression = a +o;
                        _isOldEntry = true;
                    }
                }
                else if ("." == ch)
                {
                    //小数点
                    if (string.IsNullOrEmpty(Expression))
                    {
                        if (!Result.Contains("."))
                        {
                            if (_isOldEntry)
                            {
                                Result = "0.";
                                b = Result;
                                _isOldEntry = false;
                            }
                            else
                            {
                                if (Result.Contains("."))
                                    return;
                                Result += ".";
                                b = Result;
                            }
                        }

                    }
                    else if (Expression == (a+"="))
                    {
                        if (_isOldEntry)
                        {
                            Result = "0.";
                            b = Result;
                            _isOldEntry = false;
                        }
                        else
                        {
                            if (Result.Contains("."))
                                return;
                            Result += ".";
                            b = Result;
                        }
                    }
                    else if (Expression == (a + o)&&!string.IsNullOrEmpty(o))
                    {
                        if (_isOldEntry)
                        {
                            Result = "0.";
                            b = Result;
                            _isOldEntry = false;
                        }
                        else
                        {
                            if (Result.Contains("."))
                                return;
                            Result += ".";
                            b = Result;
                        }
                    }
                    else if (Expression == (a + o +b+ "=")&&(!string.IsNullOrEmpty(o))&&(!string.IsNullOrEmpty(b)))
                    {
                        Result = "0.";
                        a = Result;
                        b = string.Empty;
                        o = string.Empty;
                        Expression = string.Empty;
                        _isOldEntry = false;
                    }
                }
                else if ("CE" == ch)
                {
                    //清楚输入框
                    if (string.IsNullOrEmpty(Expression))
                    {
                        a = "0";
                        Result = a;
                        _isOldEntry = false;
                    }
                    else if (Expression == (a+o))
                    {
                        Result = "0";
                    }
                    else if (Expression == (a+o+b+"="))
                    {
                        //全清
                        a = "0";
                        Result = a;
                        Expression = string.Empty;
                        o = string.Empty;
                        b = string.Empty;
                        _isOldEntry = false;
                    }
                }
                else if ("C" == ch)
                {
                    //清除所有
                    a = "0";
                    b = string.Empty;
                    Result = a;
                    Expression = string.Empty;
                }
                else if ("del"==ch)
                {
                    if (!_isOldEntry&&Result.Length>0)
                    {
                        if ((Expression == (a+o)&&(!string.IsNullOrEmpty(o)))||(string.IsNullOrEmpty(Expression)))
                        {
                            Result = Result.Substring(0, Result.Length -1);
                            if (string.IsNullOrEmpty(Result))
                                Result = "0";
                            b = Result;
                        }
                    }
                }
                else
                {
                    //输入数字
                    if (string.IsNullOrEmpty(Expression))
                    {
                        a = Convert.ToDecimal(Result+ch).ToString();
                        Result = a;
                    }
                    else if (Expression == (a+o))
                    {
                        if (_isOldEntry)
                        {
                            Result = ch;
                            b = ch;
                            _isOldEntry = false;
                        }
                        else
                        {
                            b = Convert.ToDecimal(Result+ch).ToString();
                            Result = b;
                        }
                    }
                    else if (Expression == (a+"="))
                    {
                        if (_isOldEntry)
                        {
                            Result = ch;
                            a = ch;
                            _isOldEntry = false;
                        }
                        else
                        {
                            a = Convert.ToDecimal(Result+ch).ToString();
                            Result = a;
                        }
                    }
                    else if (Expression == (a+o+b+"="))
                    {
                        //全清
                        a = ch;
                        Result = a;
                        Expression = string.Empty;
                        o = string.Empty;
                        b = string.Empty;
                        _isOldEntry = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //全清
                a = "0";
                Result = a;
                Expression = string.Empty;
                o = string.Empty;
                b = string.Empty;
                _isOldEntry = false;
            }
        }
    }
}
