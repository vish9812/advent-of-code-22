public static class Part2
{
  public static void Solve()
  {
    var maxes = Enumerable.Repeat(0, 3).ToList();
    var runningSum = 0;
    foreach (var calorie in File.ReadLines("input.txt"))
    {
      if (string.IsNullOrEmpty(calorie))
      {
        ReplaceMin(maxes, runningSum);
        runningSum = 0;
        continue;
      }

      runningSum += Convert.ToInt32(calorie);
    }

    ReplaceMin(maxes, runningSum);
    System.Console.WriteLine(maxes.Sum());

    static void ReplaceMin(List<int> maxes, int runningSum)
    {
      var minIdx = maxes.IndexOf(maxes.Min());
      maxes[minIdx] = Math.Max(runningSum, maxes[minIdx]);
    }
  }
}