using System.Text;

public class Part2
{
  public void Solve()
  {
    // Process Lines
    var stackLines = new List<string>();
    var opsLines = new List<string>();
    var cols = 0;
    foreach (var line in File.ReadLines("input.txt"))
    {
      if (line.Length == 0) continue;

      if (line[0] == 'm') opsLines.Add(line);
      else if (line[1] == '1') cols = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
      else stackLines.Add(line);
    }

    // Create Stacks
    var stacks = new List<List<char>>(Enumerable.Range(0, cols).Select(x => new List<char>()));
    for (int i = stackLines.Count - 1; i >= 0; i--)
    {
      var line = stackLines[i];

      for (int j = 0; j < line.Length; j++)
      {
        if (line[j] == '[')
        {
          stacks[j / 4].Add(line[j + 1]);
        }
      }
    }

    // Performs ops
    foreach (var op in opsLines)
    {
      var nums = op.Split(" ").Where(x => char.IsDigit(x, 0)).Select(int.Parse).ToList();

      var delStack = stacks[nums[1] - 1];
      var addStack = stacks[nums[2] - 1];
      var ctr = nums[0];
      var idx = delStack.Count - ctr;

      var stack = delStack.Skip(idx);
      addStack.AddRange(stack);
      delStack.RemoveRange(idx, ctr);
    }

    var builder = new StringBuilder();
    foreach (var stack in stacks)
    {
      builder.Append(stack.Last());
    }

    System.Console.WriteLine(builder.ToString());
  }
}