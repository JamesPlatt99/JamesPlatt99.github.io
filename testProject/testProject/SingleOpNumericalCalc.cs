using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject
{
    class SingleOpNumericalCalc
    {
        public void StartSingleOpNumericalCalc()
        {
            List<int> numbers = new List<int>();
            Char op = '+';
            int result = 0;

            numbers = GetNumbers();
            op = GetOperator();
            result = CalculateResult(numbers, op);

            foreach(int number in numbers)
            {
                Program.logger.WriteText(number.ToString());
            }
            Program.logger.WriteText(result.ToString());

            Console.WriteLine(result);
        }

        private List<int> GetNumbers()
        {
            List<int> numbers = new List<int>();
            String input = "";
            Console.WriteLine("Please enter 1 integer per line. To finish adding numbers enter 'f'.");
            
            while (true)
            {   
                input = Console.ReadLine();
                if (input == "f")
                {
                    break;
                }
                if (Program.IsValid(input, 1)) { 
                    numbers.Add(Convert.ToInt32(input));
                }
                else
                {                   
                    Console.WriteLine("     Or you can enter 'f' to to finish");
                    Console.WriteLine();
                }
            }
            return numbers;

        }

        private Char GetOperator()
        {
            Boolean valid = false;
            Console.Write("Please enter the operator you would like to use: ");
            String input = "";
            while(!valid)
            {
                try { 
                    input = Console.ReadLine();
                    valid = Program.IsValid(input, 0);
                    if (!valid)
                    {
                        throw new UnsupportedOperatorException(input.ToCharArray()[0]);
                    }
                }
                catch(UnsupportedOperatorException ex)
                {
                    Console.WriteLine("Error, {0}" , ex.Message );
                }
            }
            return input.ToCharArray()[0];
        }

        private int CalculateResult(List<int> numbers, Char op)
        {
            switch (op)
            {
                case '+':
                    return numbers.Sum();                    
                case '-':
                    return numbers.Skip(1).Aggregate(numbers[0], (result, curNum) => result - curNum);
                case '/':
                    return numbers.Skip(1).Aggregate(numbers[0], (result, curNum) => result / curNum);
                case '*':
                    return numbers.Aggregate(1, (result, curNum) => result * curNum);
            }
            return 1;
        }
    }
}
