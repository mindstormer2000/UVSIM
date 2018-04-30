
namespace UVSim.AddressSpace
{
    /// <summary>
    /// Represents a single instruction stored in Memory, with a breakpoint flag.
    /// </summary>
    /// <author>
    /// Emily S.
    /// </author>
    public class Instruction
    {
        /// <summary>
        /// Flag to determine if the processor should pause on this instruction
        /// </summary>
        public bool Breakpoint { get; set; }

        /// <summary>
        /// Data stored in instruction, can include opcode, operand, or signed data
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instruction to be stored in memory
        /// </summary>
        /// <param name="breakpoint">Flag for if the processor should pause on instruction</param>
        /// <param name="instruction">Data to be processed</param>
        public Instruction(bool breakpoint, string instruction)
        {
            Breakpoint = breakpoint;
            Value = instruction;
        }
    }
}
