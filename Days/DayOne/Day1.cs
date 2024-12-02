using System.Collections;

namespace AoC.Days
{
    public static class Day1
    {
        public static void Run()
        {
            var ListOne = new List<int>() {3,4,2,1,3,3};
            var ListTwo = new List<int>() {4,3,5,3,9,3};
            var initialSize = ListOne.Count;
            int TotalCount = 0;
            for (int i = 0; i < initialSize; i++)
            {
                TotalCount += Math.Abs(ListOne.Min() - ListTwo.Min());
                ListOne.Remove(ListOne.Min());
                ListTwo.Remove(ListTwo.Min());
            }
            Console.WriteLine(TotalCount);
        }
    }
}