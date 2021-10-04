using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Parser
    {
        private string input;
        private char[] arrInput;
        private decimal op1;
        private decimal op2;
        private char opmark;
        private bool stop = false;
        private int count_op_mark = 0;

        public void Instructions()
        {
            Console.WriteLine("Інструкція:");
            Console.WriteLine();
            Console.WriteLine("В рядку нижче введіть вираз, який містить 2 операнди та знак дії між ними: \nДодавання '+' \nВіднімання '-' \nМноження '*' \nДілення '\'");
            Console.WriteLine();
            Console.WriteLine("Вираз можна вводити по 1 операнду та знаку дії на 1 рядок.");
            Console.WriteLine();
            Console.WriteLine("Все, що не є операндами та знаком дії буде проігноровано.");
            Console.WriteLine();
        }

        private void Input()
        {
            input = Console.ReadLine();
            input = input
                .Replace(" ", "")
                .Replace(",", ".")
                .Replace("=", "");

            arrInput = input.ToCharArray();

            foreach (var t in arrInput)
            {
                if (t == '+' || t == '-' || t == '*' || t == '/')
                {
                    count_op_mark++;
                }
            }
        }

        private static decimal ParseDecimal(string c)
        {
            return decimal.Parse(
                c,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.InvariantCulture
            );
        }

        private bool OperatorFind()
        {
            if (arrInput.Length != 0)
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == '+' || arrInput[i] == '-' || arrInput[i] == '*' || arrInput[i] == '/')
                    {
                        opmark = arrInput[i];
                        return true;
                    }
                }
            }

            return false;
        }

        private void ParseLeftOperand()
        {
            string firstOperand = "";
            OperatorFind();

            if (arrInput.Length != 0)
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == opmark)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            firstOperand += arrInput[j];
                        }
                    }
                }

                if (OperatorFind() == false)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        firstOperand += arrInput[i];
                    }
                }
            }

            if (firstOperand != "")
            {
                try
                {
                    op1 = ParseDecimal(firstOperand);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Перший операнд введено неправильно.");
                    stop = true;
                }
            }
        }

        private void ParseRightOperand()
        {
            string secondOperand = "";
            bool o = false;
            if (OperatorFind() == false)
            {
                Input();
                OperatorFind();
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == opmark)
                    {
                        o = true;
                    }
                }
                if (OperatorFind() == true && o == true)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        if (arrInput[i] == opmark)
                        {
                            for (int j = i + 1; j < arrInput.Length; j++)
                            {
                                secondOperand += arrInput[j];
                            }
                        }
                    }
                }

                if (secondOperand == "" && OperatorFind() == true)
                {
                    Input();
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        secondOperand += arrInput[i];
                    }
                }
            }
            else if (OperatorFind() == true)
            {
                for (int i = 0; i < arrInput.Length; i++)
                {
                    if (arrInput[i] == opmark)
                    {
                        o = true;
                    }
                }

                if (o == true)
                {
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        if (arrInput[i] == opmark)
                        {
                            for (int j = i + 1; j < arrInput.Length; j++)
                            {
                                secondOperand += arrInput[j];
                            }
                        }
                    }
                }

                if (secondOperand == "")
                {
                    Input();
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        secondOperand += arrInput[i];
                    }
                }
            }


            if (secondOperand != "")
            {
                try
                {
                    op2 = ParseDecimal(secondOperand);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Другий операнд введено неправильно.");
                    stop = true;
                }
            }

        }

        public void Parse()
        {
            Input();
            ParseLeftOperand();
            ParseRightOperand();
        }

        public void Result()
        {
            decimal result;
            if (count_op_mark > 1)
            {
                Console.WriteLine("Введено більше ніж 1 знак дії.");
                stop = true;
            }

            if (stop == false)
            {
                if (opmark == '+')
                {
                    Calculator calculator = new Calculator();
                    result = calculator.Add(op1, op2);
                }
                else if (opmark == '-')
                {
                    Calculator calculator = new Calculator();
                    result = calculator.Substract(op1, op2);
                }
                else if (opmark == '*')
                {
                    Calculator calculator = new Calculator();
                    result = calculator.Multiply(op1, op2);
                }
                else
                {
                    Calculator calculator = new Calculator();
                    result = calculator.Divide(op1, op2);
                }

                Console.WriteLine($"{op1} {opmark} {op2} = {result}");
            }
        }
    }
}
