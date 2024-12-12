using System.Text.RegularExpressions;

namespace AoC.Days
{
    public class Day3
    {
        private static int TotalCount;
        public static void Run()
        {
            List<(int x, int y)> parsedList = ParseToList();
            calcTotal(parsedList);
        }

        private static List<(int, int)> ParseToList()
        {
            string filePath = "Days/DayThree/input.txt";
            string fileContent = File.ReadAllText(filePath);

            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

            List<(int x, int y)> parsedList = new List<(int x, int y)>();

            foreach (Match match in Regex.Matches(fileContent, pattern))
            {
                if (int.TryParse(match.Groups[1].Value, out int x) && int.TryParse(match.Groups[2].Value, out int y))
                {
                    parsedList.Add((x, y));
                }
            }

            Console.WriteLine("Parsed values:");
            foreach (var (x, y) in parsedList)
            {
                Console.WriteLine($"x: {x}, y: {y}");
            }
            Console.WriteLine("List count: " + parsedList.Count());
            return parsedList;
        }

        private static void calcTotal(List<(int x, int y)> parsedList)
        {
            foreach (var (x, y) in parsedList)
            {
                TotalCount += x * y;
            }
            Console.WriteLine("Sum of all product: " + TotalCount);
        }

    }
}