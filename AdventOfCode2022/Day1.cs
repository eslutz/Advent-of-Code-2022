namespace AdventOfCode2022
{
	public class Day1 : IDay
	{
		private readonly string _inputFile = "Input/Day_1_Input.txt";
		private readonly Elf _part1ElfWithMostCalories;
		private readonly int _part2TopElvesCaloriesCombined;
		private readonly List<Elf> _elves = new();

		public Day1()
		{
			string line;
			using (StreamReader file = new(_inputFile))
			{
				var currentElf = new Elf();
				while ((line = file.ReadLine()!) is not null)
				{

					if (!int.TryParse(line, out int calories))
					{
						_elves.Add(currentElf);
						currentElf = new Elf();
					}
					else
					{
						currentElf.AddCalories(calories);
					}
				}
				file.Close();
			}

			_part1ElfWithMostCalories = Part1GetElfWithMostCalories();
			_part2TopElvesCaloriesCombined = Part2GetTopElvesCaloriesCombined();
		}

		public void Run()
		{
			Console.WriteLine($"Part 1 - Elf {_part1ElfWithMostCalories.ElfNumber} has the most calories of:" +
				$" {_part1ElfWithMostCalories.Calories}");
			Console.WriteLine($"Part 2 - The top three elves have a combined caloric content of:" +
				$" {_part2TopElvesCaloriesCombined} calories");
		}

		private Elf Part1GetElfWithMostCalories()
		{
			Elf mostCaloricElf = _elves[0];
			foreach (var elf in _elves)
			{
				if (elf.Calories > mostCaloricElf.Calories)
				{
					mostCaloricElf = elf;
				}
			}
			return mostCaloricElf;
		}

		private int Part2GetTopElvesCaloriesCombined()
		{
			return _elves.OrderByDescending(elf => elf.Calories)
				.Take(3)
				.Select(elf => elf.Calories)
				.Sum();
		}
	}

	public class Elf
	{
		private static int counter;
		public int ElfNumber { get; private set; }
		public int Calories { get; private set; }

		public Elf()
		{
			ElfNumber = ++counter;
			Calories = 0;
		}

		public void AddCalories(int calories)
		{
			Calories += calories;
		}
	}
}
