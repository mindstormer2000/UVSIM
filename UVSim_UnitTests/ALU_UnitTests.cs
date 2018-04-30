using System;
using UVSim.CPU;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UVSim_UnitTests
{
    /// <summary>
    /// Represents the test cases that the ALU needs to pass to become verified
    /// </summary>
    [TestClass]
    public class ALU_UnitTests
    {
        #region Addition
        /// <summary>
        /// Tests that the ALU can add positive numbers
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestAddPositive()
        {
			// Arrange
            int inputA = 5;
            int inputB = 10;
            const int EXPECTED = 15;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
			// Act
            alu.Add();
			// Assert
            Assert.AreEqual(EXPECTED, alu.Output);
        }

        /// <summary>
        /// Tests that the ALU can add negative numbers, creating a 
        /// larger negative number
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestAddNegative()
        {
            int inputA = -2;
            int inputB = -3;
            const int EXPECTED = -5;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Add();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        #endregion
        #region Subtraction
        /// <summary>
        /// Tests that the ALU can subtract two positive numbers
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestSubtractPositive()
        {
            int inputA = 10;
            int inputB = 5;
            const int EXPECTED = 5;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Subtract();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        /// <summary>
        /// Tests that the ALU can subtract two negative numbers, resulting in
        /// a smaller negative number.
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestSubtractNegative()
        {
            int inputA = -3;
            int inputB = -2;
            const int EXPECTED = -1;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Subtract();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        #endregion
        #region Multiplication
        /// <summary>
        /// Tests that the ALU can multiply two positive numbers
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestMultplicationBothPositive()
        {
            int inputA = 2;
            int inputB = 3;
            const int EXPECTED = 6;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Multiply();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        /// <summary>
        /// Tests that the ALU can multiply two negative numbers
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestMultplicationBothNegative()
        {
            int inputA = -2;
            int inputB = -3;
            const int EXPECTED = 6;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Multiply();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        /// <summary>
        /// Tests that the ALU can multiply one positive and one negative number
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestMultplicationMixed()
        {
            int inputA = -2;
            int inputB = 3;
            const int EXPECTED = -6;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Multiply();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        #endregion
        #region Division
        /// <summary>
        /// Tests that the ALU can divide two positive numbers
        /// </summary>
        [TestMethod, TestCategory("Daily")]
        public void TestDivisionPositive()
        {
            int inputA = 10;
            int inputB = 5;
            const int EXPECTED = 2;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Divide();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        /// <summary>
        /// Tests that the ALU can divide two negative numbers
        /// </summary>
        [TestMethod]
        public void TestDivisionNegative()
        {
            int inputA = -10;
            int inputB = -5;
            const int EXPECTED = 2;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Divide();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        // ToDo: Create test case for mixed sign division
        #endregion
        #region Modulo
        /// <summary>
        /// Tests that the ALU can modulo two positive numbers
        /// with a zero remainder
        /// </summary>
        [TestMethod, TestCategory("Daily")]
        public void TestModuloZeroRemainder()
        {
            int inputA = 10;
            int inputB = 5;
            const int EXPECTED = 0;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Modulo();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        /// <summary>
        /// Tests that the ALU can modulo two positive numbers
        /// with a non-zero remainder
        /// </summary>
        [TestMethod, TestCategory("Daily")]
        public void TestModuloNonZeroRemainder()
        {
            int inputA = 13;
            int inputB = 5;
            const int EXPECTED = 3;
            ArithmeticLogicUnit alu = new ArithmeticLogicUnit()
            {
                InputA = inputA,
                InputB = inputB
            };
            alu.Modulo();
            Assert.AreEqual(EXPECTED, alu.Output);
        }
        #endregion
    }
}
