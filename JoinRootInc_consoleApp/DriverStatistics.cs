using System;
using System.Collections.Generic;
using System.Text;

namespace JoinRootInc_consoleApp
{
    /// <summary>
    /// Driver statistics
    /// </summary>
    public class DriverStatistics
    {

        public string driverName;

        public string miles;

        public string speed;

        public DriverStatistics(string driverName, string miles, string speed)
        {
            this.driverName = driverName;
            this.miles = miles;
            this.speed = speed;
        }
    }
}
