using System.Collections;

namespace AoC.Days
{
    public class Day1
    {
        private static List<int> ListOne = new List<int>();
        private static List<int> ListTwo = new List<int>();
        private static int TotalCount;
        public static void Run()
        {
            Parse();

            //Choose which one to run :)
            Similarity();
            //Distance();
        }

        private static void Distance()
        {
            var initialSize = ListOne.Count;
            TotalCount = 0;
            for (int i = 0; i < initialSize; i++)
            {
                TotalCount += Math.Abs(ListOne.Min() - ListTwo.Min());
                ListOne.Remove(ListOne.Min());
                ListTwo.Remove(ListTwo.Min());
            }
            Console.WriteLine("Distance score" + TotalCount);
        }

        private static void Similarity() {
            TotalCount = 0;
            foreach (var number in ListOne)
            {
              int count = ListTwo.Where(x => x.Equals(number)).Count();  
              TotalCount += number * count;
            }
            Console.WriteLine("Similarity score " + TotalCount);
        }

        private static void Parse()
        {
            string filePath = "Days/DayOne/input.txt";

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {

                    string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 2)
                    {
                        ListOne.Add(int.Parse(parts[0]));
                        ListTwo.Add(int.Parse(parts[1]));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading or processing the file: " + ex.Message);
            }
        }

    }
}