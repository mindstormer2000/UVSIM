
namespace UVSim.CPU
{
    /// <summary>
    /// Represents the possible error(s) that the Processor could encounter
    /// </summary>
    [System.Flags]
    public enum StatusCode
    {
        None = 0,
        InvalidOperation = 1,
        OutOfMemory = 2,
        Breakpoint = 4
    }

    /// <summary>
    /// Represents the available registers of a Processor
    /// </summary>
    [System.Serializable]
    public struct Registers
    {
        private int accumulator;

        /// <summary>
        /// Shows the status code if the processor crashes
        /// </summary>
        public StatusCode Status { get; set; }

        /// <summary>
        /// Register used with ALU calculations
        /// </summary>
        public int Accumulator {
            get
            {
                return accumulator;
            }
            set
            {
                accumulator = value % 1000000;
            }
        }

        /// <summary>
        /// The line number the processor is on
        /// </summary>
        public int ProgramCounter { get; set; }
        /// <summary>
        /// Indicates whether the processor is running or not
        /// </summary>
        public bool IsRunning { get; set; }
    }
}