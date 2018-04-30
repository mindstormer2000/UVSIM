using UVSim.AddressSpace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UVSim_UnitTests
{
    /// <summary>
    /// Represents the collection of unit test for the Memory class
    /// </summary>
    [TestClass]
    public class Memory_UnitTests
    {
        /// <summary>
        /// Tests the basic initialization of the memory
        /// and verifies that all address spaces are properly set
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestMemoryInitialization()
        {
            Memory.Initialize(new System.Collections.Generic.List<Instruction>());
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual("+0000", Memory.Get(i));
            }
        }
        /// <summary>
        /// Tests the <c>Memory.Get</c> and <c>Memory.Set</c> methods
        /// </summary>
        [TestMethod, TestCategory("Weekly")]
        public void TestInstructionManipulation()
        {
            Memory.Initialize(new System.Collections.Generic.List<Instruction>());
            Memory.Set(0, false, "+0001");
            Assert.AreEqual("+0001", Memory.Get(0));
        }
    }
}
