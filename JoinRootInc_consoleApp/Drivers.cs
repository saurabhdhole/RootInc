using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JoinRootInc_consoleApp
{

    /// <summary>
    /// Driver Registry
    /// </summary>
    public class Drivers
    {
        /// <summary>
        /// list of register drivers
        /// </summary>
        private List<string> drivers = new List<string>();

        /// <summary>
        /// list of registered drivers trip
        /// </summary>
        private List<Trip> trips = new List<Trip>();

        /// <summary>
        /// Returns true if driver registered successfully, else driver already exist or exception occurred
        /// </summary>
        /// <param name="driverName"></param>
        /// <returns></returns>
        public bool RegisterDriver(string driverName)
        {
            bool isRegistered = false;
            try
            {
                if(!drivers.Contains(driverName))
                {
                    drivers.Add(driverName);
                    isRegistered = true;
                }
            }
            catch(Exception ex)
            {
                isRegistered = false;
            }
            return isRegistered;
        }

        /// <summary>
        /// Returns registred list
        /// </summary>
        /// <returns></returns>
        public List<Trip> GetRegisteredTrips()
        {
            return trips;
        }

        /// <summary>
        /// Register the trip
        /// </summary>
        /// <param name="driverName">driver Name</param>
        /// <param name="startTime"> trip start time</param>
        /// <param name="endTime">trip end time</param>
        /// <param name="miles">miles driven</param>
        /// <returns></returns>
        public bool RegisterTrip(string driverName, DateTime startTime, DateTime endTime, float miles)
        {
            bool isAdded = false;
            try
            {
                //check if driver is registered
                // if exist add record and return true
                if (drivers.Contains(driverName))
                {
                    //check if finish time is greater than start time
                    if (endTime > startTime)
                    {
                        float speed = (float)Math.Round( miles / (endTime - startTime).TotalHours);
                        if (speed >= 5 && speed <= 100)
                        {
                            trips.Add(new Trip(driverName, startTime.ToString("HH:mm"), endTime.ToString("HH:mm"), miles, speed));
                            isAdded = true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                isAdded = false;
            }
            return isAdded;
        }

        /// <summary>
        /// Generate Report
        /// </summary>
        /// <returns></returns>
        public List<DriverStatistics> ComputeReport()
        {
            List<DriverStatistics> reports = new List<DriverStatistics>();

            try
            {
                foreach (var driver in drivers)
                {
                    float totalMiles = trips.Where(x => x.driverName == driver).Sum(x => x.miles);
                    float avSpeed = (totalMiles == 0 ? 0 :trips.Where(x => x.driverName == driver).Average(x => x.speed));

                    reports.Add(new DriverStatistics(driver, totalMiles.ToString(), avSpeed.ToString()));
                    reports = reports.OrderByDescending(x => x.miles).ToList();
                }
            }
            catch(Exception ex)
            {
                
            }

            return reports;
        }
    }

}
