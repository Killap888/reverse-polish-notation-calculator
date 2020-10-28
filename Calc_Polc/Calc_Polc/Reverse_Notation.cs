using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_Polc
{
    class Reverse_Notation
    {

        //Метод возвращает true, если проверяемый символ - разделитель ("пробел" или "равно")
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }

        //Метод возвращает true, если проверяемый символ - оператор
        static private bool IsOperator(char с)
        {
            if (("+-/*^()%\u221a".IndexOf(с) != -1))
                return true;
            return false;
        }

        //Метод возвращает приоритет оператора
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                case '\u221a': return 6;
                case '%': return 7;
                default: return 8;
            }
        }

        //"Входной" метод класса
        static public double Calculate(string input)
        {
            string output = GetExpression(input); //Преобразовываем выражение в постфиксную запись
            double result = Counting(output); //Решаем полученное выражение
            return result; //Возвращаем результат
        }


        static private string GetExpression(string input)
        {
            string output = string.Empty; 
            Stack<char> operStack = new Stack<char>(); 

            for (int i = 0; i < input.Length; i++) 
            {
                
                if (IsDelimeter(input[i]))
                    continue; 

                //Если символ - цифра, то считываем все число
                if (Char.IsDigit(input[i])) 
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i]; 
                        i++; 

                        if (i == input.Length) break; 
                    }

                    output += " "; 
                    i--; 
                }

                //Если символ - оператор
                if (IsOperator(input[i])) 
                {
                    if (input[i] == '(') 
                        operStack.Push(input[i]); 
                    else if (input[i] == ')') 
                    { 
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0) 
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) 
                                output += operStack.Pop().ToString() + " "; 

                        operStack.Push(char.Parse(input[i].ToString())); 

                    }
                }
            }

            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (operStack.Count > 0)
            {
                output += operStack.Pop() + " ";
            }               
            return output; //Возвращаем выражение в постфиксной записи
        }

        static private double Counting(string input)
        {
            double result = 0; 
            Stack<double> temp = new Stack<double>(); //стек для решения

            for (int i = 0; i < input.Length; i++)
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a += input[i]; 
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a)); 
                    i--;
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    if(input[i]== '%' || input[i] == '\u221a')
                    {
                        double c = temp.Pop();
                        switch (input[i])
                        {
                            case '%': result = double.Parse(c.ToString()) / 100; break;
                            case '\u221a': result = double.Parse(Math.Sqrt(double.Parse(c.ToString())).ToString()); break;
                        }

                    }
                    else
                    {                        
                        double a = temp.Pop();
                        double b = temp.Pop();

                        switch (input[i])
                        {
                            case '+': result = b + a; break;
                            case '-': result = b - a; break;
                            case '*': result = b * a; break;
                            case '/': result = b / a; break;
                            case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                            case '\u221a': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                            //case '%': result = double.Parse(b.ToString()) / 100; break;
                        }
                    }
                   
                    temp.Push(result); 
                }
            }
            return temp.Peek(); 
        }

    }
}
