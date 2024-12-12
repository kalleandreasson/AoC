using System;
using AoC.Days;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the day you want to run: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Day1.Run();
                break;
            case "2":
                Day2.Run();
                break;
            case "3":
                Day3.Run();
                break;
            default:
                Console.WriteLine("Invalid input. Please enter a valid day number.");
                break;
        }
    }
}