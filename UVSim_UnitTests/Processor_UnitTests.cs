using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UVSim.IO;
using UVSim.AddressSpace;
using UVSim.CPU;

namespace UVSim_UnitTests
{
    /// <summary>
    /// Represents the test cases that the ALU needs to pass to become verified
    /// </summary>
    [TestClass]
    public class Processor_UnitTests
    {
        /*
        /// <summary>
        /// Tests whether the processor can run basic simulation commands
        /// </summary>
        /// <remarks>
        /// Instructions tested:
        /// 10 Read
        /// 11 Write
        /// 20 Load
        /// 21 Store
        /// 30 Add
        /// 31 Subtract
        /// 40 Branch
        /// 43 HALT
        /// </remarks>
        // Disabling the TestMethod due to automated build issues
        // [TestMethod, TestCategory("Manual")]
        public void TestProcessorRunBasic()
        {
            #region Variables
            const string EXPECTED = "+0002";
            string actual = "";
            bool finished = false;
            #endregion
            
            #region ioBus Creation
            IOBus bus = new IOBus(
                new System.Action<System.Action<string>, string>( (act, str) => {
                    act(str);
                    return;
                }),//ExecuteAction
                new System.Action<string>((str) => {
                    finished = true;
                    return;
                }),//memdump
                new System.Func<string>(() => {
                    return "+0002";
                }),//Read
                (str) => { return; },//DisplayRuntimeData
                new System.Action<string>(x =>
                {
                    actual = x.Split(' ')[6];
                    return;
                })//Write
                );
            #endregion

            List<string> mem = new List<string>
            {
                "+1010",
                "+2010",
                "+2111",
                "+3011",
                "+3111",
                "+4007",
                "+0000",
                "+2112",
                "+1112",
                "+4300",
                "+0000"
            };
            Memory.Initialize(new List<Instruction>());
            for (int i = 0; i < mem.Count; i++)
            {
                Memory.Set(i, mem[i]);
            }

            Processor processor = new Processor(bus, 0);
            processor.Run(0);
            while (!finished)
            {

            }

            Assert.AreEqual(EXPECTED, actual);
        }

        /// <summary>
        /// Tests whether the processor can run medium simulation commands
        /// </summary>
        /// <remarks>
        /// Instructions tested:
        /// 10 Read
        /// 11 Write
        /// 20 Load
        /// 21 Store
        /// 30 Add
        /// 31 Subtract
        /// 32 Multiply
        /// 33 Divide
        /// 40 Branch
        /// 41 Branch neg
        /// 42 Branch zero
        /// 43 HALT
        /// </remarks>
        // Disabling the TestMethod due to automated build issues
        // [TestMethod, TestCategory("Manual")]
        public void TestProcessorRunStandard()
        {
            #region Variables
            List<string> EXPECTED = new List<string> { "+0008", "+0002", "+0006", "+0002", "+1234" };
            List<string> actual = new List<string> { };
            bool finished = false;
            #endregion

            #region IOBus Creation
            IOBus bus = new IOBus(
                new System.Action<System.Action<string>, string>((act, str) => {
                    act(str);
                    return;
                }),//ExecuteAction
                new System.Action<string>((str) => {
                    finished = true;
                    return;
                }),//memdump
                new System.Func<string>(() => {
                    return "+0002";
                }),//Read
                (str) => { return; },//DisplayRuntimeData
                new System.Action<string>(x =>
                {
                    actual.Add( x.Split(' ')[6]);
                    return;
                })//Write
                );
            #endregion

            List<string> mem = new List<string> { 
                "+1024",
                "+2024",
                "+3327",
                "+2125",
                "+1125",
                "+3227",
                "+2125",
                "+1125",
                "+3027",
                "+2125",
                "+1125",
                "+3127",
                "+2125",
                "+1125",
                "+4016",
                "+0000",
                "+2026",
                "+4119",
                "+0000",
                "+2018",
                "+4222",
                "+1234",
                "+1121",
                "+4300",
                "+0000",
                "+0000",
                "-0001",
                "+0004"
            };
            Memory.Initialize(new List<Instruction>());
            for (int i = 0; i < mem.Count; i++)
            {
                Memory.Set(i, mem[i]);
            }

            Processor processor = new Processor(bus, 0);
            processor.Run(0);
            while (!finished)
            {

            }
            CollectionAssert.AreEqual(EXPECTED, actual);
        }
        */
    }
}
