public static class Part1
{
  public static void Solve()
  {
    var max = 0;
    var runningSum = 0;
    foreach (var calorie in File.ReadLines("input.txt"))
    {
      if (string.IsNullOrEmpty(calorie))
      {
        max = Math.Max(max, runningSum);
        runningSum = 0;
        continue;
      }

      runningSum += Convert.ToInt32(calorie);
    }

    max = Math.Max(max, runningSum);
    System.Console.WriteLine(max);
  }
}