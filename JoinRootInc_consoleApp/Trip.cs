using System;
using System.Collections.Generic;
using System.Text;

namespace JoinRootInc_consoleApp
{

    /// <summary>
    /// Registered drivers records
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// Driver Name
        /// </summary>
        public string driverName;

        /// <summary>
        /// Trip start time
        /// </summary>
        public string startTime;

        /// <summary>
        /// Trip end time
        /// </summary>
        public string endTime;

        /// <summary>
        /// miles driven
        /// </summary>
        public float miles;

        /// <summary>
        /// speed
        /// </summary>
        public float speed;

        public Trip(string driverName, string startTime, string endTime, float miles, float speed)
        {
            this.driverName = driverName;
            this.startTime = startTime;
            this.endTime = endTime;
            this.miles = miles;
            this.speed = speed;
        }
    }
}
