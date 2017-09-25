using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject
{


    internal class NumericalCalc
    {        
        public  void StartNumCalc()
        {
            Char[] operators = new char[0];
            int[] numbers = new int[0];
            String[] inputTMP;

            Boolean valid = false;
            int curNum;
            Char curOp = '+';
            int result = 0;

            while (!valid) { 
            inputTMP = GetUserInputNumericalCalc();
            operators = GetOpArray(inputTMP, ref valid);
            numbers = GetNumArray(inputTMP, ref valid);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                curNum = numbers[i];
                curOp = operators[i];
                result = PerformOneNumericalCalculation(curOp, result, curNum);
            }
            Console.WriteLine("The result of this calculation is: {0:N}", result);
        }

        private int PerformOneNumericalCalculation(Char op, int result, int number)
        {
            switch (op)
            {
                case '+':
                    result += Convert.ToInt32(number);
                    break;
                case '-':
                    result -= Convert.ToInt32(number);
                    break;
                case '*':
                    result = result * Convert.ToInt32(number);
                    break;
                case '/':
                    result = result / Convert.ToInt32(number);
                    break;
            }
            return result;
        }

        private string[] GetUserInputNumericalCalc()
        {
            Console.WriteLine(" When entering a calculation, be sure to seperate each number/ operator using a space.");
            Console.WriteLine("   e.g 12 * 3 + 4");
            Console.WriteLine();
            Console.Write("   Enter calculation: ");
            string[] userInput = Console.ReadLine().Split(' ');
            return userInput;
        }

        private int[] GetNumArray(string[] input, ref Boolean valid)
        {
            int[] output = new int[(input.Length / 2) + 1];
            int curOutPutIndex = 0;
            for (int i = 0; i < input.Length; i += 2)
            {
                if (!(valid = Program.IsValid(input[i], 1)))
                {
                    return new int[0];
                }
                output[curOutPutIndex] = Convert.ToInt32(input[i]);
                curOutPutIndex++;
            }
            return output;
        }

        private Char[] GetOpArray(string[] input, ref Boolean valid)
        {
            char[] output = new char[(input.Length / 2) + 1];
            //The first number should always be added to the result first
            output[0] = '+';
            int curOutPutIndex = 1;
            for (int i = 1; i < input.Length - 1; i += 2)
            {
                if (!(valid = Program.IsValid(input[i], 0)))
                {
                    return new char[0];
                }
                output[curOutPutIndex] = input[i].ToCharArray()[0];
                curOutPutIndex++;
            }
            return output;
        }
    }
}
