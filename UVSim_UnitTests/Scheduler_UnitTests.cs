using System.Collections.Generic;
using UVSim.IO;
using UVSim.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UVSim_UnitTests
{
    /// <summary>
    /// Represents the test cases that the ALU needs to pass to become verified
    /// </summary>
    [TestClass]
    public class Scheduler_UnitTests
    {
        /// <summary>
        /// Tests whether processors can be added to a Scheduler
        /// </summary>
        [TestMethod, TestCategory("Nightly")]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestScheduleProcessor()
        {
            List<ThreadedProcessor> EXPECTED = new List<ThreadedProcessor>();
            IOBus bus = new IOBus();

            Scheduler.ScheduleProcessor(bus, 1);
            Scheduler.ScheduleProcessor(bus, 2);

            // Test, it should throw an exception when attempting to add another
            // procesor with the same ID as previous
            Scheduler.ScheduleProcessor(bus, 1);
        }
    }
}
