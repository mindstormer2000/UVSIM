
namespace UVSim.Threading
{
    public struct ThreadManager
    {
        /// <summary>
        /// The thread id that is running the code
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The thread that is running the code
        /// </summary>
        public System.Threading.Thread Sequencer { get; set; }
    }
}
