namespace AoC.Days
{
    public class Day2
    {
        private static List<List<int>> bigList = new List<List<int>>();
        private static int TotalCount;
        public static void Run()
        {
            Parse();
            CheckIfSaveProblemDampener();
            //CheckIfSafe();
        }

        private static void CheckIfSafe()
        {
            foreach (var smallList in bigList)
            {
                bool isIncreasing = false;
                bool isDecreasing = false;

                for (int i = 1; i < smallList.Count; i++)
                {
                    if (!isDecreasing && smallList[i] > smallList[i - 1] && smallList[i] <= smallList[i - 1] + 3)
                    {
                        isIncreasing = true;

                        if (i == smallList.Count - 1)
                        {
                            TotalCount++;
                        }
                    }
                    else if (!isIncreasing && smallList[i] < smallList[i - 1] && smallList[i] >= smallList[i - 1] - 3)
                    {
                        isDecreasing = true;

                        if (i == smallList.Count - 1)
                        {
                            TotalCount++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("Safe levels: " + TotalCount);
        }

        private static void CheckIfSaveProblemDampener()
        {
            foreach (var smallList in bigList)
            {
                bool isSafe = IsValidSequence(smallList);

                if (!isSafe)
                {
                    for (int i = 0; i < smallList.Count; i++)
                    {
                        var modifiedList = new List<int>(smallList);
                        modifiedList.RemoveAt(i);

                        if (IsValidSequence(modifiedList))
                        {
                            isSafe = true;
                            break;
                        }
                    }
                }
                if (isSafe)
                {
                    TotalCount++;
                }
            }
            Console.WriteLine("Safe levels: " + TotalCount);
        }

        static bool IsValidSequence(List<int> list)
        {
            bool isIncreasing = false;
            bool isDecreasing = false;

            for (int i = 1; i < list.Count; i++)
            {
                if (!isDecreasing && list[i] > list[i - 1] && list[i] <= list[i - 1] + 3)
                {
                    isIncreasing = true;
                }
                else if (!isIncreasing && list[i] < list[i - 1] && list[i] >= list[i - 1] - 3)
                {
                    isDecreasing = true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static void Parse()
        {
            string filePath = "Days/DayTwo/input.txt";

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    List<int> smallList = new List<int>();
                    foreach (string part in parts)
                    {
                        smallList.Add(int.Parse(part));
                    }
                    bigList.Add(smallList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing the file: " + ex.Message);
            }

        }

    }
}