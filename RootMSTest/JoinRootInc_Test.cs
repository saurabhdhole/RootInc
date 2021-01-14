using JoinRootInc_consoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RootMSTest
{
    [TestClass]
    public class JoinRootInc_Test
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Parameter are missing")]
        public void CommandLineArgumentMissing()
        {
            string[] argument = { };
            JoinRootInc.Main(argument);
            Assert.Fail();
        }
    }
}
