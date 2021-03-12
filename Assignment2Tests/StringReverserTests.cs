using Assignment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;

namespace Assignment2Tests
{
    [TestClass]
    public class Program2Test
    {
        string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "lines.txt");

        [TestMethod]
        public void AssertFileReaderNotNull()
        {
            StringReverser sr = new StringReverser();
            Assert.IsNotNull(sr.GetFileReader());
        }

        [TestMethod]
        public void CheckReverseEquals()
        {
            string[] values = new string[]{"dlrow olleh"};

            Mock<FileReader> fileReaderMock = new Mock<FileReader>();
            fileReaderMock.Setup(x => x.GetLinesFromTextFile(filePath)).Returns(values);
            Assignment2.StringReverser stringReverser = new Assignment2.StringReverser(fileReaderMock.Object);

            //ASSUMES: There was at least one entry given to the mock filereader
            Assert.AreEqual("hello world", stringReverser.getReversedStringsFromFile(filePath)[0]);
        }

        [TestMethod]
        public void CheckNonAlphaPalindromeReverse()
        {
            string[] value = new string[]{")(()"};

            Mock<FileReader> fileReaderMock = new Mock<FileReader>();
            fileReaderMock.Setup(x => x.GetLinesFromTextFile(filePath)).Returns(value);
            Assignment2.StringReverser stringReverser = new Assignment2.StringReverser(fileReaderMock.Object);

            //ASSUMES: There was at least one entry given to the mock filereader
            Assert.AreEqual(")(()", stringReverser.getReversedStringsFromFile(filePath)[0]);
        }

        [TestMethod]
        public void CheckAlphaPalindromeReverse()
        {
            string[] value = new string[]{"racecar"};

            Mock<FileReader> fileReaderMock = new Mock<FileReader>();
            fileReaderMock.Setup(x => x.GetLinesFromTextFile(filePath)).Returns(value);
            Assignment2.StringReverser stringReverser = new Assignment2.StringReverser(fileReaderMock.Object);

            //ASSUMES: There was at least one entry given to the mock filereader
            Assert.AreEqual("racecar", stringReverser.getReversedStringsFromFile(filePath)[0]);
        }

        [TestMethod]
        public void CheckNonAlphaCharReverse()
        {
            string[] value = new string[]{"+12$5^09"};

            Mock<FileReader> fileReaderMock = new Mock<FileReader>();
            fileReaderMock.Setup(x => x.GetLinesFromTextFile(filePath)).Returns(value);
            Assignment2.StringReverser stringReverser = new Assignment2.StringReverser(fileReaderMock.Object);

            //ASSUMES: There was at least one entry given to the mock filereader
            Assert.AreEqual("90^5$21+", stringReverser.getReversedStringsFromFile(filePath)[0]);
        }
    }
}
