using System;
using System.Collections.Generic;

namespace Assignment2
{
    class StringReverser
    {
        FileReader fileReader;

        string[] lines;

        public StringReverser()
        {
            fileReader = new FileReader();
        }

        public StringReverser(FileReader fileReader)
        {
            this.fileReader = new FileReader();
        }

        public List<string> getReversedStringsFromFile(string filePath)
        {
            try
            {
                lines = fileReader.GetLinesFromTextFile(filePath);
            }
            catch (Exception e)
            {
                throw e;
            }

            List<string> reversedLines = new List<string>();

            foreach(string line in lines)
            {
                char[] lineAsArray = line.ToCharArray();
                Array.Reverse(lineAsArray);
                reversedLines.Add(new string(lineAsArray));
            }
            return reversedLines;
        }
    }
}
