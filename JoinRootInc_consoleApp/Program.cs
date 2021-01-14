using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

namespace JoinRootInc_consoleApp
{
    public class JoinRootInc
    {
        public static void Main(string[] args)
        {
            if(args.Length == 1)
            {
                try
                {
                    string fileName = args[0];
                    List<string> commands = File.ReadAllLines(fileName).ToList();

                    //create instance of Driver class
                    Drivers joinRootDriver = new Drivers();

                    foreach (var command in commands)
                    {
                        var splits = command.Split(" ");

                        //check driver command and register driver
                        if(splits[0].ToLower() == "driver")
                        {
                            joinRootDriver.RegisterDriver(splits[1]);
                            continue;
                        }

                        //register trip
                        if (splits[0].ToLower() == "trip")
                        {
                            joinRootDriver.RegisterTrip(splits[1], GetDate(splits[2]), GetDate(splits[3]), float.Parse(splits[4]));
                            continue;
                        }
                    }

                    //IList<Trip> trips = joinRootDriver.GetRegisteredTrips();

                    List<DriverStatistics> reports = joinRootDriver.ComputeReport();

                    foreach (var report in reports)
                    {
                        Console.WriteLine(report.driverName + ": " + report.miles + " miles " + (report.miles == "0"? "": " @ "+report.speed + " mph"));
                    }
                }
                catch(Exception ex)
                {
                    
                }
            }
            else
            {
                throw new ArgumentException("Parameter are missing");
            }
        }

        /// <summary>
        /// Convert string to datetime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetDate(string time)
        {
            try
            {
                return DateTime.ParseExact(time, "HH:mm",
                                        CultureInfo.InvariantCulture);
                
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }
    }
}
