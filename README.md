# Driver Behavior Pattern Demo

A C# example to push a new Driver Behavior Patterns with the Device Manager Api .
For this demo, the program was written with Visual Studio 2013 community edition.
You must "Enable nuget package restore" before compile the projet (Right click on the solution).

# Configure the program

You need to update source code (program.cs) to declare your Imeis and token for authentication.

# Execution

The program builds a default driver pattern (used internal class), serializes in Json format and puts this message through Api on the device manager.
You will see the posted message in "Asset > Details > History of the messages" on each of your assets or from the page "Apps" click on "History" on the application "Driver Behavior".


