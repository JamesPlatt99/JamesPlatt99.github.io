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
            Boolean valid;
            int calcMode = 0;


            PrintWelcomeMessage();

            while (true) {
                valid = false;
                while (!valid)
                {
                    if ((calcMode = getCalcMode(ref valid)) == 1)
                    {
                        NumericalCalc numericalCalc = new NumericalCalc();
                        numericalCalc.StartNumCalc();
                    }
                    else
                    {
                        DateTimeCalc dateTimeCalc = new DateTimeCalc();
                        dateTimeCalc.StartDateCalc();
                    }

                }
                Console.WriteLine("..");
                Console.ReadLine();
                Console.WriteLine();

            }
        }

        private static int getCalcMode(ref Boolean valid)
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

        public static Boolean IsValid(string input, int type)
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

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to my Calculator.");
            Console.WriteLine();

        }

        
    }
}
