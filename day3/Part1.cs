public class Part1
{
  public void Solve()
  {
    var lower = Enumerable.Range('a', 26).ToDictionary(x => (char)x, x => x - 'a' + 1);
    var upper = Enumerable.Range('A', 26).ToDictionary(x => (char)x, x => x - 'A' + 27);

    var sum = 0;
    foreach (var ruckSack in File.ReadLines("input.txt"))
    {
      var first = new HashSet<char>(ruckSack[..(ruckSack.Length / 2)]);
      var last = new HashSet<char>(ruckSack[^(ruckSack.Length / 2)..]);

      var common = first.Intersect(last).First();
      var priority = 0;
      if (!lower.TryGetValue(common, out priority)) upper.TryGetValue(common, out priority);
      sum += priority;
    }

    System.Console.WriteLine(sum);
  }
}