using System;
namespace testProject
{
    class Program
    {
        public static LogToFile logger = new LogToFile();

        static void Main(string[] args)

        {          
            Boolean valid = false;
            CalcType calcType = 0;

            PrintWelcomeMessage();
            logger.ClearLog();
                while (!valid)
                {
                    switch(calcType = getCalcMode(ref valid)){
                        case CalcType.Numerical:
                            NumericalCalc numericalCalc = new NumericalCalc();
                            numericalCalc.StartNumCalc();
                            break;
                        case CalcType.Date:
                            DateTimeCalc dateTimeCalc = new DateTimeCalc();
                            dateTimeCalc.StartDateCalc();
                            break;
                        case CalcType.SingleOpNumerical:
                            SingleOpNumericalCalc singleOpNumericalCalc = new SingleOpNumericalCalc();
                            singleOpNumericalCalc.StartSingleOpNumericalCalc();
                            break;
                    }
                    Console.WriteLine("..");
                    Console.ReadLine();
                    Console.WriteLine();
                valid = false;
                }
            }        

        private static CalcType getCalcMode(ref Boolean valid)
        {
            Console.WriteLine("Which calculator mode do you want?");
            Console.WriteLine("  1) Numbers");
            Console.WriteLine("  2) Date");
            Console.WriteLine("  3) Single operation (numerical)");
            String input = Console.ReadLine();
            int output = 0;
            if (valid = IsValid(input, 1))
            {
                output = Convert.ToInt32(input);
            }
                return (CalcType)output;
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

        private enum CalcType
        {
            Numerical = 1,
            Date = 2,
            SingleOpNumerical = 3
            
        };
    }
}
