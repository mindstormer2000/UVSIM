using UVSim.IO;
using UVSim.CPU;

namespace UVSim.Threading
{
    /// <summary>
    /// Represents a processor that can be used in a threaded scenario (multi-core processing)
    /// </summary>
    /// <author>Brad Van Fleet</author>
    public sealed class ThreadedProcessor : Processor
    {
        ThreadManager thread;

        /// <summary>
        /// Instantiates an instance of the Processor
        /// </summary>
        /// <param name="bus">IOBus used for communication</param>
        /// <param name="pc">Starting ProgramCounter line to start at</param>
        /// <param name="id">Processor ID</param>
        public ThreadedProcessor(IOBus bus, int pc, int id)
            : base(bus, pc)
        {
            thread = new ThreadManager {
                ID = id,
                Sequencer = new System.Threading.Thread(this.Process)
            };
        }

        /// <summary>
        /// Instantiates an instance of the Processor and starts it immediately
        /// </summary>
        /// <param name="bus">IOBus used for communication</param>
        /// <param name="pc">Starting ProgramCounter line to start at</param>
        /// <param name="id">Processor ID</param>
        /// <param name="autorun">Whether the processor should start processing after instantiation</param>
        public ThreadedProcessor(IOBus bus, int pc, int id, bool autorun)
            : this(bus, pc, id)
        {
            if (autorun)
            {
                this.Run(register.ProgramCounter);
            }
        }

        /// <summary>
        /// Starts the thread and begins processing
        /// </summary>
        /// <param name="pc">The ProgramCounter line to begin processing on</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if pc is not within the Memory range</exception>
        public override void Run(int pc)
        {
            // Ensure pc is addressible
            if (pc < 0)
            {
                throw new System.ArgumentOutOfRangeException($"Program Counter address {pc} is not valid");
            }
            register.ProgramCounter = pc;
            register.IsRunning = true;
            try
            {
                thread.Sequencer.Start();
            }
            // Catch provided in case the processor tries to run a second time and is in an invalid thread state
            catch {
                thread.Sequencer = new System.Threading.Thread(this.Process);
            }
        }

        /// <summary>
        /// Sends the value to the <c>IOBus</c> to be displayed for output
        /// </summary>
        /// <param name="value">Information to be written to output</param>
        public override void Alert(string value)
        {
            base.Alert($"Processor {thread.ID}: {value}");
        }

        /// <summary>
        /// Sends processor registers to the interface
        /// </summary>
        public override void UpdateRuntimeData()
        {
            Bus.OnUpdateRuntimeData($"{thread.ID} {register.ProgramCounter} {register.Accumulator} {register.Status}");
        }
    }
}
