using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment3;


namespace Assignment3Tests
{
    [TestClass]
    public class Assignment3Test
    {
        //ADDITION
        [TestMethod]
        public void SimpleAdditionShouldReturn()
        {
            List<double> testInputs = new List<double>(){1, 2, 3};
            Assert.AreEqual(6, RepeatedOperationCalculator.Add(testInputs));
        }

        [TestMethod]
        public void DecimalAdditionShouldReturn()
        {
            List<double> testInputs = new List<double>(){1.5, 2.5, 3};
            Assert.AreEqual(7, RepeatedOperationCalculator.Add(testInputs));
        }

        [TestMethod]
        public void NegativeAdditionShouldReturn()
        {
            List<double> testInputs = new List<double>(){-0.5, -2.5, 3};
            Assert.AreEqual(0, RepeatedOperationCalculator.Add(testInputs));
        }

        //SUBTRACTION
        [TestMethod]
        public void SimpleSubtractionShouldReturn()
        {
            List<double> testInputs = new List<double>(){1, 2, 3};
            Assert.AreEqual(-4, RepeatedOperationCalculator.Subtract(testInputs));
        }

        [TestMethod]
        public void DecimalSubtractionShouldReturn()
        {
            List<double> testInputs = new List<double>(){1.5, 2.3, 3};
            Assert.AreEqual(-3.8, RepeatedOperationCalculator.Subtract(testInputs));
        }

        [TestMethod]
        public void NegativesubtractionShouldReturn()
        {
            List<double> testInputs = new List<double>(){-0.5, -2.5, 3};
            Assert.AreEqual(-1, RepeatedOperationCalculator.Subtract(testInputs));
        }

        //Multiplication
        [TestMethod]
        public void SimpleMultiplicationShouldReturn()
        {
            List<double> testInputs = new List<double>(){1, 2, 3};
            Assert.AreEqual(6, RepeatedOperationCalculator.Multiply(testInputs));
        }

        [TestMethod]
        public void DecimalMultiplicationShouldReturn()
        {
            List<double> testInputs = new List<double>(){1.5, 2.3, 3};
            Assert.AreEqual(10.35, RepeatedOperationCalculator.Multiply(testInputs));
        }

        [TestMethod]
        public void NegativeMultiplicationShouldReturn()
        {
            List<double> testInputs = new List<double>(){-0.5, -2.5, 3};
            Assert.AreEqual(3.75, RepeatedOperationCalculator.Multiply(testInputs));
        }

        //Division
        [TestMethod]
        public void SimpleDivisionShouldReturn()
        {
            List<double> testInputs = new List<double>(){6, 3, 2};
            bool experiencedError = false;
            Assert.AreEqual(1, RepeatedOperationCalculator.Divide(testInputs, out experiencedError));
            Assert.IsFalse(experiencedError);
        }

        [TestMethod]
        public void DecimalDivisionShouldReturn()
        {
            //Tests rounding as well
            List<double> testInputs = new List<double>(){1.5, 2.3, 3};
            bool experiencedError = false;
            Assert.AreEqual(0.22, RepeatedOperationCalculator.Divide(testInputs, out experiencedError));
            Assert.IsFalse(experiencedError);
        }

        [TestMethod]
        public void NegativeDivisionShouldReturn()
        {
            List<double> testInputs = new List<double>(){-0.5, -2.5, 3};
            bool experiencedError = false;
            Assert.AreEqual(0.07, RepeatedOperationCalculator.Divide(testInputs, out experiencedError));
            Assert.IsFalse(experiencedError);
        }

        [TestMethod]
        public void ZeroDivisionShouldError()
        {
            List<double> testInputs = new List<double>(){-0.5, -2.5, 0, 3};
            bool experiencedError = false;
            Assert.AreEqual(0.2, RepeatedOperationCalculator.Divide(testInputs, out experiencedError));
            Assert.IsTrue(experiencedError);
        }

        //Average
        [TestMethod]
        public void SimpleAverageShouldReturn()
        {
            List<double> testInputs = new List<double>(){1, 2, 3};
            Assert.AreEqual(2, RepeatedOperationCalculator.Average(testInputs));
        }

        [TestMethod]
        public void DecimalAverageShouldReturn()
        {
            //Tests rounding as well
            List<double> testInputs = new List<double>(){1.5, 2.3, 3};
            Assert.AreEqual(2.27, RepeatedOperationCalculator.Average(testInputs));
        }

        [TestMethod]
        public void NegativeAverageShouldReturn()
        {
            List<double> testInputs = new List<double>(){-0.5, -2.5, 3};
            Assert.AreEqual(0, RepeatedOperationCalculator.Average(testInputs));
        }

        [TestMethod]
        public void NoInputAverageShouldReturn()
        {
            List<double> testInputs = new List<double>();
            Assert.AreEqual(0, RepeatedOperationCalculator.Average(testInputs));
        }
    }
}
