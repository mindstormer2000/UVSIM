/// AUTHOR: Brad Van Fleet
/// Milestone #1
/// Date: 2/15/2018
namespace UVSim.CPU
{
    /// <summary>
    /// Represents the ALU of a processor
    /// </summary>
    /// <remarks>
    /// Developer: Brad V.
    /// </remarks>
    public class ArithmeticLogicUnit
    {
        /// <summary>
        /// Operand used in ALU operations
        /// </summary>
        public int InputA { get; set; }
        /// <summary>
        /// Operand used in ALU operations
        /// </summary>
        public int InputB { get; set; }
        /// <summary>
        /// Output of value set from ALU operations
        /// </summary>
        public int Output { get; private set; }
        
        /// <summary>
        /// Instantiates an instance of the ALU with default input and output values
        /// </summary>
        public ArithmeticLogicUnit()
        {
            InputA = 0;
            InputB = 0;
            Output = 0;
        }

        #region Operators
        /// <summary>
        /// Adds InputA and InputB and sets value to Output
        /// </summary>
        public void Add()
        {
            // Instantiate carry bit and mask
            int mask = 0x0001;
            int carry = 0x0000;
            // Clear Output
            Output = 0;
            // Loop based upon the mask, stop once the mask bit overflows
            while (mask != 0)
            {
                // A ^ B == 0
                if (((InputA & mask) ^ (InputB & mask)) == 0)
                {
                    if (carry == 1)
                    {
                        Output ^= mask;
                    }
                    // carryOut = A & B != 0 ? 1 : 0
                    carry = ((InputA & mask) & (InputB & mask)) != 0 ? 0x0001 : 0x0000;
                }
                // A ^ B != 0
                else if (carry == 0)
                {
                    Output ^= mask;
                }
                else
                {
                    carry = 1;
                }
                // Shift mask bit left
                mask <<= 1;
            }
        }

        /// <summary>
        /// Subtracts InputA and InputB and sets value to Output
        /// </summary>
        public void Subtract()
        {
            // Instantiate a temp register to maintain original value
            // This is done for repeated arithmetic to maintain accuracy
            int tempB = InputB;
            Output = 0;
            NegateB();
            InputB = Output;
            Add();
            InputB = tempB;
        }

        /// <summary>
        /// Multiplies InputA by InputB and sets value to Output
        /// </summary>
        public void Multiply()
        {
            Output = 0;
            int maxBound = System.Math.Abs(InputB);
            if (InputA < 0 && InputB < 0) // -A x -B = Y
            {
                NegateA();
                NegateB();
            }
            // A x -B = -Y
            if (InputA > 0 && InputB < 0)
            {
                NegateA();
            }
            // All other cases don't require any additional processing,
            // as the result should be treated the same
            for (int i = 0; i < maxBound; i++)
            {
                InputB = Output;
                Add();
            }
        }

        /// <summary>
        /// Divides InputA by InputB and sets value to Output
        /// </summary>
        /// <exception cref="System.DivideByZeroException">Thrown if InputB equals 0</exception>
        public void Divide()
        {
            if (InputB == 0)
            {
                throw new System.DivideByZeroException("Cannot divide by zero");
            }
            int result = 0;
            // -A / -B = Y
            if (InputA < 0 && InputB < 0)
            {
                NegateA();
                NegateB();
            }
            while (InputA >= InputB)
            {
                result += 1;
                Subtract();
                InputA = Output;
            }
            Output = result;
        }

        /// <summary>
        /// Divides InputA by InputB and sets the remainder to Output
        /// </summary>
        public void Modulo()
        {
            Divide();
            Output = InputA;
        }

        /// <summary>
        /// Raises InputA by the power of InputB and sets the result to Output
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if InputB is less than zero</exception>
        public void Exponent()
        {
            if (InputB < 0)
            {
                throw new System.InvalidOperationException("Cannot raise number by a negative power");
            }
            
            int maxBound = System.Math.Abs(InputB);
            Output = 1;
            for (int i = 0; i < maxBound; i++)
            {
                InputB = Output;
                Multiply();
            }
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Negates the number in InputB
        /// </summary>
        private void NegateB()
        {
            int tempA = InputA;
            int mask = 0x0001;
            // Make 1's compliment
            while (mask != 0)
            {
                InputB ^= mask;
                mask <<= 1;
            }
            // Make 2's compliment
            InputA = 0x0001;
            Add();
            InputA = tempA;
        }
        /// <summary>
        /// Negates the number in InputA
        /// </summary>
        private void NegateA()
        {
            int tempB = InputB;
            InputB = InputA;
            NegateB();
            InputA = InputB;
            InputB = tempB;
        }
        #endregion
    }
}
