using System;
using System.Collections.Generic;

namespace Assignment2
{
    class Program
    {
        StringReverser stringReverser = new StringReverser();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            string filePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "lines.txt");
            List<string> reversedLines = new List<string>();
            try
            {
                FileReader.CreateEmptyFile(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while creating the lines.txt file.");
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Welcome. Please fill in the lines.txt file with some strings you want to reverse.");

            Console.WriteLine("\npress any key to start the process...");

            // basic use of "Console.ReadKey()" method 
            Console.ReadKey();

            Console.WriteLine("Your reversed lines are:");

            try
            {
                reversedLines = stringReverser.getReversedStringsFromFile(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while reading the lines.txt file.");
                Console.WriteLine(e.Message);
                return;
            }

            if(reversedLines.Count == 0)
            {
                Console.WriteLine("The lines.txt file was empty.");
                return;
            }

            foreach(string line in reversedLines)
            {
                Console.WriteLine(line);
            }

            try
            {
                FileReader.DeleteFile(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while deleting the lines.txt file.");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\npress any key to exit.");

            // basic use of "Console.ReadKey()" method 
            Console.ReadKey();
        }
    }
}
