# Driver Behavior Pattern Demo

A C# example to push a new Driver Behavior Patterns with the Device Manager Api .
For this demo, the program was written with Visual Studio 2013 community edition.
You must "Enable nuget package restore" before compile the projet (Right click on the solution).

# Configure the program

You need to update source code (program.cs) to declare your Imeis and token for authentication.

# Execution

The program build a default driver pattern (use internal class), serialize in Json format and push this message through Api on the device manager.
You will see the POST message in Asset > Details > History of message on each of your assets or from the page "Apps" click on "History" for the App Driver Behavior.


