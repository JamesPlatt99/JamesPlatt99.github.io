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
            int num1;
            int num2;
            Char op;
            Double result=0;
            Console.Write("Please enter an operator: ");
            op = Console.ReadLine().ToCharArray()[0];
            Console.Write("Please enter a number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter another number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
                case '*':
                    result = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Invalid Operator.");
                    break;
            }

            Console.WriteLine("The solution is: {0}", result);
            Console.ReadLine();
        }
    }
}
