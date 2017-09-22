using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Char op = 't';
            int[] input = new int[0];
            int result = 0;
            Boolean firstNumLoaded;
            Boolean valid;

            PrintWelcomeMessage();

            while (true) {
                valid = false;
                firstNumLoaded = false;
                while (!valid)
                { 
                    input = GetUserInput(ref op, ref valid);
                }

                foreach (int number in input)
                {                
                    //loads only the first number into result, skipping the switch
                    //used to allow multiplication and division to return values other than 0
                    if (!firstNumLoaded)
                    {
                        result = number;
                        firstNumLoaded = true;
                        continue;
                    }
                    result = PerformOneCalculation(op, result, number);
                }
                Console.WriteLine("The result of this calculation is: {0}", result);
                Console.ReadLine();
            }
        }

        static int PerformOneCalculation(Char op, int result, int number)
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

        static int[] GetUserInput(ref Char op, ref Boolean valid)
        {
            string tmp;
            valid = true;
            op = 't';
            Console.Write("Please select an operator: ");
            tmp = Console.ReadLine();
            if (valid = IsValid(tmp, 0))
            {
                op = tmp.ToCharArray()[0];
            }

            Console.Write("Please enter space seperated numbers: ");
            string[] input = Console.ReadLine().Split(' ');
            int[] output = new int[input.Length];
            for(int i = 0; i < input.Length; i++)
            {
                if (!IsValid(input[i],1)) {
                    valid = false;
                    return null;
                }
                output[i] = Convert.ToInt32(input[i]);
            }
            return output;
        }

        static Boolean IsValid(string input, int type)
        {
            //type 0 to check operator, 1 for int.
            int tmp;
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
                    if (int.TryParse(input, out tmp))
                    {
                        return true;
                    }
                    break;

            }
            Console.WriteLine("Invalid input! Please try again.");
            Console.WriteLine();
            return false;
        }
    }
}
