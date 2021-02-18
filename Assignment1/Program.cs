using System;

namespace Assignment1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        
        public void Run()
        {
            Console.WriteLine("Give a string to be reversed.");
            string line = Console.ReadLine();
            if(line.Length == 0)
            {
                Console.WriteLine("Empty string given.");
                return;
            }

            Console.WriteLine("The reverse of {0} is {1}", line, ReverseString(line));
        }

        public string ReverseString(string line)
        {
            char[] stringAsCharArray = line.ToCharArray();
            Array.Reverse(stringAsCharArray);
            return new string(stringAsCharArray);
        }
    }
}