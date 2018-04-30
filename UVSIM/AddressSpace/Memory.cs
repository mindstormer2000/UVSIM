/// AUTHOR: Ryley Giles, Caiden Kehrer
/// Milestone #1
/// Date: 2/15/2018

using System.Collections.Generic;
using static UVSIM.Properties.Settings;

namespace UVSim.AddressSpace
{
    // Public static only allows ONE version of memory.
    public static class Memory
    {
        private static List<Instruction> memory = new List<Instruction>(Default.MemorySize);
        private static readonly object lockObject = new object();

        /// <summary>
        /// Allows the user to retrieve a copy of the memory
        /// </summary>
        public static List<Instruction> Instructions { get { return memory; } }
        
        /// <summary>
        /// Initializes the memory with the provided list
        /// </summary>
        /// <param name="instructions"></param>
        public static void Initialize(List<Instruction> instructions)
        {
            // Ensure memory is empty and initialized to +0000
            Clear();
            lock (lockObject)
            {
                if (instructions.Count > 0 && instructions.Count <= Default.MemorySize)
                {
                    for (int idx = 0; idx < instructions.Count; idx++)
                    {
                        memory[idx] = instructions[idx];
                    }
                }
            }
        }

        #region Getters
        /// <summary>
        /// Retrieves the data at the provided address
        /// </summary>
        /// <param name="address">Location to retrieve data from</param>
        /// <returns>Data found at address</returns>
        public static string Get(int address)
        {
            if (address >= Default.MemorySize || address < 0)
            {
                return null;
            }
            lock (lockObject)
            {
                return memory[address].Value;
            }
        }

        /// <summary>
        /// Determine if a breakpoint has been set at provided address
        /// </summary>
        /// <param name="address">Location to check for breakpoint</param>
        /// <returns>True if breakpoint is set for memory address</returns>
        public static bool HasBreakpoint(int address)
        {
            if (address >= Default.MemorySize || address < 0)
            {
                return false;
            }
            lock (lockObject)
            {
                return memory[address].Breakpoint;
            }
        }
        #endregion

        #region Setters
        /// <summary>
        /// Sets the data at the provided address
        /// </summary>
        /// <param name="address">Location to store data</param>
        /// <param name="data">Information to be stored</param>
        public static void Set(int address, string data)
        {
            if (address >= Default.MemorySize || address < 0)
            {
                return;
            }
            lock (lockObject)
            {
                memory[address] = new Instruction(false, data);
            }
        }

        /// <summary>
        /// Sets the data and breakpoint flag at the provided address
        /// </summary>
        /// <param name="address">Location to store data</param>
        /// <param name="breakpoint">Breakpoint flag</param>
        /// <param name="data">Information to be stored</param>
        public static void Set(int address, bool breakpoint, string data)
        {
            if (address >= Default.MemorySize || address < 0)
            {
                return;
            }
            lock (lockObject)
            {
                memory[address] = new Instruction(breakpoint, data);
            }
        }

        /// <summary>
        /// Clears all address spaces and sets them to +0000
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Brad V.
        /// </remarks>
        public static void Clear()
        {
            lock (lockObject)
            {
                // Empty backing array
                memory.Clear();
                // Set each value to +0000
                for (int address = 0; address < Default.MemorySize; address++)
                {
                    memory.Add(new Instruction(false, "+0000"));
                }
            }
        }
        #endregion
    }
}
