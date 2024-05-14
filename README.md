# RootInc
 
I have created the structure where,
1. registered the driver and if driver is already register will discard
2. Will register the trip if driver is already register
	checks
	1. start time is greather than end time, then discard entry
	2. speed <=5 and >=100, then discard

once we got all data, computing report as per specification

This script(console application) runs on windows, linux and mac environment.
Created structure is scallable we add/create number of attributes and report as per specification.

To run through commandline,
open command prompt and traverse to .exe folder
Then run below command,
JoinRootInc_consoleApp.exe input.txt

# For Sample output, please refer output.png
