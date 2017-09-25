using System;

namespace testProject
{
    class DateTimeCalc
    {
        public void StartDateCalc()
        {
            DateTime Date = new DateTime();
            int daysToAdd = 0;
            Boolean valid = false;

            while (!valid) { 
                Date = getDateTime(ref valid);
                daysToAdd = getDaysToAdd(ref valid);
            }

            Console.WriteLine();
            Console.WriteLine("Your new date is {0:D}.", calcNewDate(Date, daysToAdd));

            Program.logger.WriteText(Date + " + " + daysToAdd);
            Program.logger.WriteText(calcNewDate(Date, daysToAdd).ToString());
        }

        DateTime getDateTime(ref Boolean valid)
        {
            Console.Write("Please enter a date: ");
            string userInput = Console.ReadLine();
            if (valid = Program.IsValid(userInput, 2))
            {
                return Convert.ToDateTime(userInput);
            }
            return DateTime.MaxValue;
        }
        int getDaysToAdd(ref Boolean valid)
        {
            Console.Write("Please enter the number of days to add: ");
            string userInput = Console.ReadLine();
            if (valid = Program.IsValid(userInput, 1))
            {
                return Convert.ToInt32(userInput);
            }
            return 0;
        }
        DateTime calcNewDate(DateTime Date, int daysToAdd)
        {
            return Date.AddDays(daysToAdd);
        }
    }
}
