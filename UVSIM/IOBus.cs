/// AUTHOR: Caiden Kehrer, Brad Van Fleet
/// Milestone #1
/// Date: 2/15/2018
using System;

namespace UVSim.IO
{
    /// <summary>
    /// This class is the interface with which the processor interacts with the GUI
    /// It is fully public
    /// </summary>
    /// <remarks>
    /// Contributors:
    /// Caiden K.
    /// Brad V.
    /// </remarks>
    public struct IOBus
    {
        public Action<Action<string>, string> ExecuteAction { get; set; }
        public Func<string> OnReadValue { get; set; }
        public Func< string> OnReadSixDigitValue { get; set; }
        private Action<string> MemDumpAction { get; set; }
        private Action<string> OnUpdateRuntimeDataAction { get; set; }
        private Action<string> OnDisplayAction { get; set; }

        /// <summary>
        /// Instantiates a new instance of the IOBus with provided handlers
        /// </summary>
        /// <param name="executeAction">A function to reattach to the GUI thread before executing some GUI function.</param>
        /// <param name="memdumpDisplay">A function to do a memory dump and display the accumulator value.</param>
        /// <param name="read">A function to request input from the user.</param>
        /// <param name="updateRuntimeData">A function to display the current accumulator value.</param>
        /// <param name="onDisplay">A function to display output to the user.</param>
        public IOBus(Action<Action<string>, string> executeAction,
            Action<string> memdumpDisplay,
            Func<string> read,
            Func<string> readSix,
            Action<string> updateRuntimeData,
            Action<string> onDisplay)
        {
            ExecuteAction = executeAction;
            OnReadValue = read;
            OnReadSixDigitValue = readSix;
            OnDisplayAction = onDisplay;
            MemDumpAction = memdumpDisplay;
            OnUpdateRuntimeDataAction = updateRuntimeData;
        }

        /// <summary>
        /// Calls the GUI's function that reattaches to the right thread and then calls the memory dump function
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Emily S.
        /// </remarks>
        /// <param name="runtimeData">The runtime data to display. Space delimited string of values (program counter, ALU, status code).</param>
        public void MemDump(string runtimeData)
        {
            ExecuteAction(MemDumpAction, runtimeData);
        }

        /// <summary>
        /// Calls the GUI's function that reattaches to the right thread and then calls the accumulator display function
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Emily S.
        /// </remarks>
        /// <param name="runtimeData">The runtime data to display. Space delimited string of values (program counter, ALU, status code).</param>
        public void OnUpdateRuntimeData(string runtimeData)
        {
            ExecuteAction(OnUpdateRuntimeDataAction, runtimeData);
        }

        /// <summary>
        /// Calls the GUI's function that reattaches to the right thread and then calls the display function
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Emily S.
        /// </remarks>
        /// <param name="displayValue">The value to display.</param>
        public void OnDisplay(string displayValue)
        {
            ExecuteAction(OnDisplayAction, displayValue);
        }
    }
}
