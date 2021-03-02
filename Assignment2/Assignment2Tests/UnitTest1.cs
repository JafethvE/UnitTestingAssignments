using Assignment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;

namespace Assignment2Tests
{

    [TestClass]
    public class UnitTest1
    {
        string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "lines.txt");

        [TestMethod]
        public void ReverseShouldReturn()
        {
            string[] values = {};
            Mock<FileReader> fileReaderMock = new Mock<FileReader>();
            fileReaderMock.Setup(x => x.GetLinesFromTextFile(filePath)).Returns(values);

        }
    }
}
