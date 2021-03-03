using System;
using System.Collections.Generic;

namespace Assignment2
{
    public class StringReverser
    {
        FileReader fileReader;

        string[] lines;

        public StringReverser()
        {
            this.fileReader = new FileReader();
        }

        public StringReverser(FileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public FileReader GetFileReader()
        {
            return fileReader;
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
