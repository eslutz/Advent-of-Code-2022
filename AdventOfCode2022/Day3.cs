namespace AdventOfCode2022
{
	public class Day3 : IDay
	{
		private readonly string _inputFile = "Input/Day_3_Input.txt";
		private readonly List<string> _rucksacks = new();
		private readonly int _part1PrioritySum, _part2PrioritySum;

		public Day3()
		{
			string line;
			using (StreamReader file = new(_inputFile))
			{
				while ((line = file.ReadLine()!) is not null)
				{
					_rucksacks.Add(line);
				}
				file.Close();
			}

			_part1PrioritySum = Part1GetPairedItemsPrioritySum();
			_part2PrioritySum = Part2GetGroupItemsPrioritySum();
		}

		public void Run()
		{
			Console.WriteLine($"Part 1 - The priority sum of the paired item type priority per rucksack is: " +
				$"{_part1PrioritySum}");
			Console.WriteLine($"Part 2 - The priority sum of the badge priority per group is: {_part2PrioritySum}");
		}

		public int Part1GetPairedItemsPrioritySum()
		{
			int prioritySum = 0;

			foreach (var rucksack in _rucksacks)
			{
				var compartment1 = rucksack[..(int)(rucksack.Length / 2)];
				var compartment2 = rucksack.Substring(
					(int)(rucksack.Length / 2),
					(int)(rucksack.Length / 2)
					);

				var itemPair = compartment1.Where(comp1 => compartment2.Any(
					comp2 => comp1.Equals(comp2)))
					.FirstOrDefault();

				prioritySum += ConvertCharToValue(itemPair);
			}

			return prioritySum;
		}

		public int Part2GetGroupItemsPrioritySum()
		{
			int prioritySum = 0;
			List<List<string>> groups = new();

			for(var i = 0; i < _rucksacks.Count; i += 3)
			{
				groups.Add(new List<string> {
					_rucksacks[i], _rucksacks[i + 1],
					_rucksacks[i + 2]
				});
			}

			foreach (var group in groups)
			{
				var badge = group[0].FirstOrDefault(letter => {
					return group[1].Contains(letter, StringComparison.InvariantCulture)
					&& group[2].Contains(letter, StringComparison.InvariantCulture);
					});

				prioritySum += ConvertCharToValue(badge, true);
			}

			//second attempt
			//var foundGroupMatch = false;
			//for (var i = 0; i < groups.Count; i++)
			//{
			//    for (var x = 0; x < groups[i][0].Length; x++)
			//    {
			//        for (var y = 0; y < groups[i][1].Length; y++)
			//        {
			//            for (var z = 0; z < groups[i][2].Length; z++)
			//            {
			//                if (groups[i][0][x] == groups[i][1][y] && groups[i][0][x] == groups[i][2][z])
			//                {
			//                    prioritySum += ConvertCharToValue(groups[i][0][x], true);
			//                    foundGroupMatch = true;
			//                    break;
			//                }
			//            }
			//            if (foundGroupMatch) { break; }
			//        }
			//        if (foundGroupMatch) { break; }
			//    }
			//    foundGroupMatch = false;
			//}

			return prioritySum;
		}

		private static int ConvertCharToValue(char letter, bool part2 = false)
		{
			int value;

			if (part2)
			{
				value = char.IsUpper(letter) ? letter - 38 : letter - 96;
			}
			else
			{
				value = char.IsUpper(letter) ? letter - 64 : letter - 70;
			}

			return value;
		}
	}
}

