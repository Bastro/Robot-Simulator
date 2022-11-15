// See https://aka.ms/new-console-template for more information
using Robot_Simulator;

Console.WriteLine("Lets run robot simulator. Enter a path to file.");
var path = Console.ReadLine() ?? "";
Simulator.Run(path);