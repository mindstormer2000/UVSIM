using System.Collections.Generic;
using UVSim.IO;

namespace UVSim.Threading
{
    /// <summary>
    /// Allows the instantiation and management of multiple Processor objects 
    /// (simulating a multi-core processor)
    /// </summary>
    /// <author>
    /// Caiden K.
    /// </author>
    public static class Scheduler
    {
        private static Dictionary<int, ThreadedProcessor> processorQueue = new Dictionary<int, ThreadedProcessor>();
        
        /// <summary>
        /// Schedules a processor to be run in the scheduler queue
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        public static void ScheduleProcessor(IOBus bus, int id)
        {
            if (processorQueue.ContainsKey(id))
            {
                throw new System.ArgumentException($"Processor with id {id} already exists!");
            }
            // Instantiate a new ThreadedProcessor and insert it into the processorQueue.
            // Set PC to 0 until future development allows custom PC value.
            processorQueue.Add(id, new ThreadedProcessor(bus, 0 , id));
        }

        #region Run Processors
        /// <summary>
        /// Begins a specified process within scheduler
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        /// <param name="process"></param>
        public static void RunProcessor(int id, int pc)
        {
            if (processorQueue[id] == null)
            {
                throw new System.ArgumentException($"There is no Processor with ID {id}");
            }
            else
            {
                processorQueue[id].Run(pc);
            } 
        }
        /// <summary>
        /// Begins all processes at their specified pc
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        public static void RunAll(List<int> pc)
        {
            int i = 0;
            if (pc != null)
            {
                foreach (var processor in processorQueue.Values)
                {
                    processor.Run(pc[i]);
                    i++;
                }
            }
            else
            {
                throw new System.ArgumentNullException("ProgramCounter list cannot be null");
            }
        }
        #endregion

        #region Stop Processors
        /// <summary>
        /// ends a specified process in scheduler
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        /// <param name="id"></param>
        public static void StopProcessor(int id)
        {
            if (processorQueue[id] == null)
            {
                throw new System.ArgumentException($"There is no Processor with ID {id}");
            }
            else
            {
                processorQueue[id].Stop();
            }
        }
        /// <summary>
        /// ends all processes in scheduler
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        public static void StopAllProcessors(bool end = false)
        {
            foreach (var processor in processorQueue.Values)
            {
                processor.Stop(end);
            }
        }
        #endregion

        #region Continue processors
        /// <summary>
        /// ends a specified process in scheduler
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        /// <param name="id"></param>
        public static void ContinueProcessor(int id)
        {
            if (processorQueue[id] == null)
            {
                throw new System.ArgumentException($"There is no Processor with ID {id}");
            }
            else
            {
                processorQueue[id].Continue();
            }
        }
        /// <summary>
        /// ends all processes in scheduler
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        public static void ContinueAllProcessors(bool end = false)
        {
            foreach (var process in processorQueue.Values)
            {
                process.Continue();
            }
        }
        #endregion

        #region Remove processors
        /// <summary>
        /// Removes and ends a specified procesor
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        /// <param name="id"></param>
        public static void RemoveProcessor(int id)
        {
            if (processorQueue[id] == null)
            {
                throw new System.ArgumentException($"No processor with ID {id} to remove");
            }
            else
            {
                processorQueue[id].Stop();
            }
        }
        /// <summary>
        /// Removes and ends all processes from scheduler
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        public static void ClearScheduler()
        {
            StopAllProcessors();
            processorQueue.Clear();
        }
        #endregion
    }
}
