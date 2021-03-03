using System;
using System.IO;

namespace Assignment2
{
    public class FileReader
    {
        public virtual string[] GetLinesFromTextFile(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            //Catch the filenotfound exception and opt to create new instead
            catch (FileNotFoundException e)
            {
                //NOTE: Normally this would be logged along with the write to console
                Console.WriteLine(e.Message);
                CreateEmptyFile(filePath);
                return new string[]{};
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void CreateEmptyFile(string filePath)
        {
            try
            {
                File.Create(filePath).Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static void DeleteFile(string filepath)
        {
            try
            {
                File.Delete(filepath);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
