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

        [TestMethod]
        public void CheckNonAlphaPalindromeReverse()
        {
            string value = ")(()";
            Program program = new Program();
            Assert.AreEqual(")(()", program.ReverseString(value));
        }

        [TestMethod]
        public void CheckAlphaPalindromeReverse()
        {
            string value = "racecar";
            Program program = new Program();

            Assert.AreEqual("racecar", program.ReverseString(value));
        }

        [TestMethod]
        public void CheckNonAlphaCharReverse()
        {
            string value = "+12$5^09";
            Program program = new Program();

            Assert.AreEqual("90^5$21+", program.ReverseString(value));
        }
    }
}
