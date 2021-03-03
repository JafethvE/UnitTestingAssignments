using Assignment1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ReverseStringShouldReturn()
        {
            string value = "hello world";
            Program program = new Program();

            Assert.AreEqual("dlrow olleh", program.ReverseString(value));
        }
    }
}
