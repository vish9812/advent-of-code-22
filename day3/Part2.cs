public class Part2
{
  Dictionary<char, int> lower = Enumerable.Range('a', 26).ToDictionary(x => (char)x, x => x - 'a' + 1);
  Dictionary<char, int> upper = Enumerable.Range('A', 26).ToDictionary(x => (char)x, x => x - 'A' + 27);
  List<HashSet<char>> group = new List<HashSet<char>>();

  public void Solve()
  {

    var sum = 0;

    foreach (var ruckSack in File.ReadLines("input.txt"))
    {
      if (group.Count == 3)
      {
        sum += Priority();
        group.Clear();
      }
      group.Add(new HashSet<char>(ruckSack));
    }

    Console.WriteLine(sum + Priority());
  }

  int Priority()
  {
    var common = group[0].Intersect(group[1]).Intersect(group[2]).First();
    var priority = 0;
    if (!lower.TryGetValue(common, out priority)) upper.TryGetValue(common, out priority);
    return priority;
  }
}