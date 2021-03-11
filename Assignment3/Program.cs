using System;
using System.Collections.Generic;

namespace Assignment3
{
    public class RepeatedOperationCalculator
    {
        // START: Const definitions

        /// <summary>
        /// Constant representing the addition operation
        /// </summary>
        const string OPERATION_ADDITION = "1";

        /// <summary>
        /// Constant representing the subtraction operation
        /// </summary>
        const string OPERATION_SUBTRACTION = "2";

        /// <summary>
        /// Constant representing the multiplication operation
        /// </summary>
        const string OPERATION_MULTIPLICATION = "3";

        /// <summary>
        /// Constant representing the division operation
        /// </summary>
        const string OPERATION_DIVISION = "4";

        /// <summary>
        /// Constant representing the average operation
        /// </summary>
        const string OPERATION_AVERAGE = "5";

        static void Main(string[] args)
        {
            //Variable defs
            string operation = "0";
            bool isInvalidOperation = false;

            //Used for output
            double result = 0;
            bool experiencedError = false;

            //Prompt user to enter numbers and parse them to a string array, splitting over space and comma delimiters
            Console.WriteLine("Please enter some numbers (you can separate by comma or space)");
            string[] inputtedNums = Console.ReadLine().Trim().Split(' ', ',');

            //Convert the inputted numbers to IEnumerable (and sanitize in the process) to prepare for the operations
            IEnumerable<double> parsedNums = GetParsedNumberEnum(inputtedNums);

            //Now prompt for the operation and loop 'till valid
            do
            {
                Console.WriteLine(
                    "\nPlease enter the operation you wish to perform on the numbers\n"
                    + "---------------------------------------------------------------"
                );
                Console.Write(
                    "\t1) Addition\n\t"
                    + "2) Subtraction\n\t"
                    + "3) Multiplication\n\t"
                    + "4) Division\n\t"
                    + "5) Average\n"
                    + "0) Exit\n\n"
                    + "Option: "
                );
                operation = Console.ReadLine();

                //Check for validity and mention if invalid
                isInvalidOperation = !"012345".Contains(operation);
                if (isInvalidOperation)
                    { Console.WriteLine("Please enter a valid option (0-5)"); }

            } while (isInvalidOperation);

            //Now select the appropriate operaton
            switch (operation)
            {
                case OPERATION_ADDITION:
                    result = Add(parsedNums);
                    break;

                case OPERATION_SUBTRACTION:
                    result = Subtract(parsedNums);
                    break;

                case OPERATION_MULTIPLICATION:
                    result = Multiply(parsedNums);
                    break;

                case OPERATION_DIVISION:
                    result = Divide(parsedNums, out experiencedError);
                    break;

                case OPERATION_AVERAGE:
                    result = Average(parsedNums);
                    break;

                default:
                    Console.WriteLine("Goodbye.");
                    Environment.Exit(0);
                    break;
            }

            //We should notify that an error occurred and the result wasn't calculable, otherwise we can just print the result
            if (experiencedError)
                { Console.WriteLine("Errors occurred and the result could not be calculated."); }
            else
                { Console.WriteLine($"The result of your requested operation on the inputted numbers is: {result}."); }
        }

        /// <summary>
        /// GetParsedNumberEnum - Gets an IEnumerable representing the parsed number
        ///
        /// NOTE: Accounts for misinput and sanitizes appropriately
        /// </summary>
        /// <param name="unparsedNums">the string array containing all the unparsed numbers</param>
        /// <returns>IENumerable representing the parsed numbers to be used in calculations</returns>
        public static IEnumerable<double> GetParsedNumberEnum(string[] unparsedNums)
        {
            //Since all processes involving the numbers will only involve iteration without modification,
            //we should convert the input to double and return an ienum for quicker iteration
            foreach (string unparsedNum in unparsedNums)
            {
                double parsedNum = 0;

                //Since it's possible to enter an extra space by accident, we shouldn't consider it 0, but a mistake
                if (unparsedNum.Trim().Length == 0)
                    { continue; }

                bool parsed = double.TryParse(unparsedNum, out parsedNum);

                //Log parsing failure along with bad value
                if (!parsed)
                    { WriteError($"[ERROR]: Failed to parse value: {unparsedNum} to double. Treating failed parse value as 0."); }

                //Yield return the IEnum
                yield return parsedNum;
            }
        }

        /// <summary>
        /// Addition method, adds all values in the parsedNums IEnumerable and returns the sum
        /// </summary>
        /// <param name="parsedNums">numbers to add</param>
        /// <returns>Sum of all inputted numbers</returns>
        public static double Add(IEnumerable<double> parsedNums)
        {
            double sum = 0.0;
            foreach (double num in parsedNums)
                { sum += num; }

            return sum;
        }

        /// <summary>
        /// Overload for Addition, this variation accepts an `out` parameter which counts the amount of numbers added
        /// </summary>
        /// <param name="parsedNums">numbers to add</param>
        /// <param name="count">variable to export which will contain the amount of numbers added</param>
        /// <returns>Sum of all given numbers, and the amount of numbers added via `count`</returns>
        public static double Add(IEnumerable<double> parsedNums, out int count)
        {
            count = 0;
            double sum = 0.0;
            foreach (double num in parsedNums)
            {
                sum += num;
                count++;
            }

            return sum;
        }

        /// <summary>
        /// Subtraction method, subtracts all values given (in order)
        /// </summary>
        /// <param name="parsedNums">numbers to subtract</param>
        /// <returns>the value of all the numbers given, subtracted</returns>
        public static double Subtract(IEnumerable<double> parsedNums)
        {
            double? total = null;
            foreach (double num in parsedNums)
            {
                //Since we can't blindly start from 0, we must set total to the first value so we can peform operations on it
                if (total is null)
                {
                    total = num;
                    continue;
                }

                total -= num;
            }

            //Force conversion from double? to double
            return Convert.ToDouble(total);
        }

        /// <summary>
        /// Multiplication method, multiplies all given numbers together
        /// </summary>
        /// <param name="parsedNums">numbers to multiply</param>
        /// <returns>the product of all the numbers multiplied together</returns>
        public static double Multiply(IEnumerable<double> parsedNums)
        {
            //Start this at 1 so the first number will always be applied
            double product = 1;
            foreach (double num in parsedNums)
                { product *= num; }

            return product;
        }

        /// <summary>
        /// Division method, divides all the numbers given
        ///
        /// NOTE: Reports if errors occurred and sets a flag (experiencedError if so)
        /// NOTE: If an error occurred, this function returns the quotient UP TO the value which errored
        /// </summary>
        /// <param name="parsedNums">numbers to divide</param>
        /// <param name="experiencedError">flag marking if this method experienced an error</param>
        /// <returns>The quotient of the numbers given and whether or not an error was experienced</returns>
        public static double Divide(IEnumerable<double> parsedNums, out bool experiencedError)
        {
            double? quotient = null;
            experiencedError = false;
            foreach (double num in parsedNums)
            {
                //Put the first item in
                if (quotient is null)
                {
                    quotient = num;
                    continue;
                }

                //Handle the divide by zero case
                if (num == 0)
                {
                    WriteError($"[ERROR]: Zero division encountered ({quotient} would be divided by {num})");
                    experiencedError = true;
                    break;
                }

                //Finally with checks completed:
                quotient /= num;
            }

            //Once again, force a conversion to double from double?. We'll also round to 2 decimal places here for cleanliness
            return Math.Round(Convert.ToDouble(quotient), 2);
        }

        /// <summary>
        /// Average method, returns the average of all given number
        /// </summary>
        /// <param name="parsedNums">numbers to calculate the average from</param>
        /// <returns>average of the given numbers</returns>
        public static double Average(IEnumerable<double> parsedNums)
        {
            int count = 0;
            double sum = Add(parsedNums, out count);

            //If there were no values given, simply return 0
            if (count == 0)
                { return 0; }

            //With checks completed, return the quotient of sum/amount of entries (rounded to 2 decimal places)
            return Math.Round(sum/count, 2);
        }

        /// <summary>
        /// Error logging function. Prints custom errors in red to console
        /// </summary>
        /// <param name="message">Text to print to console</param>
        static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
