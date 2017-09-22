using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject
{
    class Program
    {
        private const int numberCalculator = 1;
        private const int dateCalculator = 2;

        static void Main(string[] args)
        {


            Char[] operators = new char[0];            
            int[] numbers = new int[0];
            int result = 0;
            Boolean valid;
            string[] inputTMP;
            int calcMode = 0;

            int curNum;
            Char curOp = '+';

            DateTime Date = new DateTime();
            int daysToAdd = 0;

            PrintWelcomeMessage();

            while (true) {
                valid = false;
                result = 0;
                while (!valid)
                {
                    if ((calcMode = getCalcMode(ref valid)) == 1)
                    {
                        //Numerical Calculator
                        inputTMP = GetUserInputNumericalCalc();
                        operators = GetOpArray(inputTMP, ref valid);
                        numbers = GetNumArray(inputTMP, ref valid);
                    }
                    else
                    {
                        //Date Calculator
                        Date = getDateTime(ref valid);
                        daysToAdd = getDaysToAdd(ref valid);
                    }

                }

                switch (calcMode)
                {
                    case 1:
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            curNum = numbers[i];
                            curOp = operators[i];
                            result = PerformOneNumericalCalculation(curOp, result, curNum);
                        }
                        Console.WriteLine("The result of this calculation is: {0:N}", result);
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Your new date is {0:D}.", calcNewDate(Date,daysToAdd));
                        break;
                }
                Console.WriteLine("..");
                Console.ReadLine();
                Console.WriteLine();

            }
        }

        static int getCalcMode(ref Boolean valid)
        {
            Console.WriteLine("Which calculator mode do you want?");
            Console.WriteLine("  1) Numbers");
            Console.WriteLine("  2) Date");
            String input = Console.ReadLine();
            int output = 0;
            if (valid = IsValid(input, 1))
            {
                output = Convert.ToInt32(input);
            }
            return output;
        }


        static Boolean IsValid(string input, int type)
        {
            //type 0 to check operator, 1 for int, 2 for DateTime.           
            if (input.Length == 0)
            {
                Console.WriteLine("Invalid input! Please try again.");
                Console.WriteLine();
                return false;
            }

            switch (type)
            {
                case 0:
                    if (input.ToCharArray()[0] == '+' | input.ToCharArray()[0] == '-' | input.ToCharArray()[0] == '*' | input.ToCharArray()[0] == '/')
                    {
                        return true;
                    }
                    break;
                case 1:
                    int tmp;
                    if (int.TryParse(input, out tmp))
                    {
                        return true;
                    }
                    break;
                case 2:
                    DateTime tmpDate = new DateTime();
                    if(DateTime.TryParse(input, out tmpDate))
                    {
                        return true;
                    }
                    break;
            }
            Console.WriteLine("Invalid input! Please try again.");
            Console.WriteLine();
            return false;
        }

        //Numerical Calc Subroutines
        static int PerformOneNumericalCalculation(Char op, int result, int number)
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

        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to my Calculator.");
            Console.WriteLine();
            
        }

        static string[] GetUserInputNumericalCalc()
        {
            Console.WriteLine(" When entering a calculation, be sure to seperate each number/ operator using a space.");
            Console.WriteLine("   e.g 12 * 3 + 4");
            Console.WriteLine();
            Console.Write("   Enter calculation: ");
            string[] userInput = Console.ReadLine().Split(' ');
            return userInput;
        }

        static int[] GetNumArray(string[] input, ref Boolean valid)
        {
            int[] output = new int[(input.Length / 2) + 1];
            int curOutPutIndex = 0;
            for(int i = 0; i<input.Length; i += 2)
            {
                if (!(valid = IsValid(input[i],1)))
                {
                    return new int[0];
                }
                output[curOutPutIndex] = Convert.ToInt32(input[i]);
                curOutPutIndex++;
            }
            return output;
        }

        static Char[] GetOpArray(string[] input, ref Boolean valid)
        {
            char[] output = new char[(input.Length / 2) + 1];
            //The first number should always be added to the result first
            output[0] = '+';
            int curOutPutIndex = 1;
            for (int i = 1; i < input.Length -1 ; i += 2)
            {
                if (!(valid = IsValid(input[i], 0)))
                {
                    return new char[0];
                }
                output[curOutPutIndex] = input[i].ToCharArray()[0];
                curOutPutIndex++;
            }
            return output;
        }



        //Date Calc Subroutines
        static DateTime getDateTime(ref Boolean valid)
        {
            Console.Write("Please enter a date:");
            string userInput = Console.ReadLine();
            if (valid = IsValid(userInput, 2)) {
                return Convert.ToDateTime(userInput);
            }
            return DateTime.MaxValue;
        }
        static int getDaysToAdd(ref Boolean valid)
        {
            Console.Write("Please enter the number of days to add: ");
            string userInput = Console.ReadLine();
            if (valid = IsValid(userInput, 1))
            {
                return Convert.ToInt32(userInput);
            }
            return 0;
        }
        static DateTime calcNewDate(DateTime Date, int daysToAdd)
        {
            return Date.AddDays(daysToAdd);
        }
    }
}
