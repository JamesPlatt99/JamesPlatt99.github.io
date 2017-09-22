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
            Char op;
            string[] input;
            int result = 0;
            int number;
            Boolean firstNumLoaded = false;

            Console.Write("Please select an operator: ");
            op = Console.ReadLine().ToCharArray()[0];
            Console.Write("Please enter space seperated numbers: ");
            input = Console.ReadLine().Split(' ');

            foreach(string numberSTR in input)
            {
                number = Convert.ToInt32(numberSTR);
                //loads only the first number into result, skipping the switch
                //used to allow multiplication and division to return values other than 0
                if (!firstNumLoaded)
                {
                    result = number;
                    firstNumLoaded = true;
                    continue;
                }
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
            }
            Console.WriteLine("The result of this calculation is: {0}", result);
            Console.ReadLine();
        }
    }
}
