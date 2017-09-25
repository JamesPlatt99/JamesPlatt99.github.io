using System;
using System.Collections.Generic;

namespace testProject
{


    internal class NumericalCalc
    {        
        public  void StartNumCalc()
        {
            List<Char> operators = new List<Char>();
            List<int> numbers = new List<int>();
            List<String> inputTMP;
            String calcStr = "";

            Boolean valid = false;
            int curNum;
            Char curOp = '+';
            int result = 0;

            while (!valid) { 
            inputTMP = GetUserInputNumericalCalc();
            operators = GetOpArray(inputTMP, ref valid);
            numbers = GetNumArray(inputTMP, ref valid);
            calcStr = usrInputToStr(inputTMP);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                curNum = numbers[i];
                curOp = operators[i];
                result = PerformOneNumericalCalculation(curOp, result, curNum);
            }
            Console.WriteLine("The result of this calculation is: {0:N}", result);
            Program.logger.WriteText(calcStr);
            Program.logger.WriteText(result.ToString());
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

        private List<String> GetUserInputNumericalCalc()
        {
            Console.WriteLine(" When entering a calculation, be sure to seperate each number/ operator using a space.");
            Console.WriteLine("   e.g 12 * 3 + 4");
            Console.WriteLine();
            Console.Write("   Enter calculation: ");
            string[] userInput = Console.ReadLine().Split(' ');
            List<String> userInputList = new List<String>();
            foreach (String number in userInput)
            {
                userInputList.Add(number);
            }
            return userInputList;
        }

        private List<int> GetNumArray(List<String> input, ref Boolean valid)
        {
            List<int> output = new List<int>();
            for (int i = 0; i < input.Count; i += 2)
            {
                if (!(valid = Program.IsValid(input[i], 1)))
                {
                    return new List<int>();
                }
                output.Add(Convert.ToInt32(input[i]));
            }
            return output;
        }

        private List<Char> GetOpArray(List<String> input, ref Boolean valid)
        {
            List<Char> output = new List<Char>();
            //The first number should always be added to the result first
            output.Add('+');
            for (int i = 1; i < input.Count - 1; i += 2)
            {
                if (!(valid = Program.IsValid(input[i], 0)))
                {
                    return new List<Char>();
                }
                output.Add(input[i].ToCharArray()[0]);
            }
            return output;
        }

        private String usrInputToStr(List<String> inputArray)
        {
            String inputString = "";
            foreach(String element in inputArray)
            {
                inputString += element;
            }
            return inputString;
        }
    }
}
