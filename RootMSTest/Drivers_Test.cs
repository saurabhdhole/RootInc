using JoinRootInc_consoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RootMSTest
{
    [TestClass]
    public class Drivers_Test
    {

        [TestMethod]
        public void Register_Driver()
        {
            Drivers drivers = new Drivers();
            string driverName = "Dan";
            bool result = drivers.RegisterDriver(driverName);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Register_SameDriverTwice()
        {
            Drivers drivers = new Drivers();
            string driverName = "Dan";
            bool result = drivers.RegisterDriver(driverName);
            bool result1 = drivers.RegisterDriver(driverName);

            Assert.IsFalse(result1);
        }


        [TestMethod]
        public void RegisterTrip_StartTimeGreaterThanEndTime()
        {
            Drivers drivers = new Drivers();
            string driverName = "Dan";
            drivers.RegisterDriver(driverName);
            //07:15 07:45
            DateTime startTime = JoinRootInc.GetDate(" 07:45");
            DateTime endTime = JoinRootInc.GetDate("07:15");
            float miles = 17.3f;

            bool result = drivers.RegisterTrip(driverName, startTime, endTime, miles);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RegisterTrip_DriverIsNotRegistered()
        {
            Drivers drivers = new Drivers();
            string driverName = "Dan";
            drivers.RegisterDriver(driverName);
            //07:15 07:45
            DateTime startTime = JoinRootInc.GetDate(" 07:45");
            DateTime endTime = JoinRootInc.GetDate("07:15");
            float miles = 17.3f;

            bool result = drivers.RegisterTrip("Kumi", startTime, endTime, miles);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RegisterTrip_RegisteredDriver()
        {
            Drivers drivers = new Drivers();
            string driverName = "Dan";
            drivers.RegisterDriver(driverName);
            //07:15 07:45
            DateTime startTime = JoinRootInc.GetDate("07:15");
            DateTime endTime =  JoinRootInc.GetDate(" 07:45");
            float miles = 45.3f;

            bool result = drivers.RegisterTrip(driverName, startTime, endTime, miles);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RegisterTrip_SpeedLessthan5OrGreaterThan100()
        {
            Drivers drivers = new Drivers();
            string driverName = "Dan";
            drivers.RegisterDriver(driverName);
            //07:15 07:45
            DateTime startTime = JoinRootInc.GetDate("07:15");
            DateTime endTime = JoinRootInc.GetDate(" 07:45");
            float miles = 0.3f;

            bool result = drivers.RegisterTrip(driverName, startTime, endTime, miles);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ComputeReport()
        {
            Drivers drivers = new Drivers();
            string driverName = "Dan";
            drivers.RegisterDriver(driverName);
            //07:15 07:45
            DateTime startTime = JoinRootInc.GetDate("07:15");
            DateTime endTime = JoinRootInc.GetDate(" 07:45");
            float miles = 45.2f;

            bool result = drivers.RegisterTrip(driverName, startTime, endTime, miles);

            int count = drivers.ComputeReport().Count;
            Assert.IsTrue((count==1? true: false));
        }
    }
}
