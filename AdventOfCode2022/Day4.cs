using System.Globalization;

namespace AdventOfCode2022
{
	public class Day4 : IDay
	{
		private readonly string _inputFile = "Input/Day_4_Input.txt";
		private readonly List<string[]> _pairs = new();
		private readonly int _part1ConsumedPairPartners;

		public Day4()
		{
			string line;
			using (StreamReader file = new(_inputFile))
			{
				while ((line = file.ReadLine()!) is not null)
				{
					_pairs.Add(line.Split(','));
				}
				file.Close();
			}

			_part1ConsumedPairPartners = Part1GetConsumedPairPartners();
		}

		public void Run()
		{
			Console.WriteLine($"Part 1 - The number of ranges consumed by their partner is: {_part1ConsumedPairPartners}");
		}

		private int Part1GetConsumedPairPartners()
		{
			var consumedPartnersCount = 0;
			foreach(var pair in _pairs)
			{
				var range = pair[0].Split('-');
				int[] rangeOne = { int.Parse(range[0], CultureInfo.InvariantCulture), int.Parse(range[1], CultureInfo.InvariantCulture) };
				 range = pair[1].Split('-');
				int[] rangeTwo = { int.Parse(range[0], CultureInfo.InvariantCulture), int.Parse(range[1], CultureInfo.InvariantCulture) };

				// if rangeTwo fits inside rangeOne or rangeOne fits inside rangeTwo, then increment counter
				if((rangeOne[0] <= rangeTwo[0] && rangeOne[1] >= rangeTwo[1]) ||
					(rangeTwo[0] <= rangeOne[0] && rangeTwo[1] >= rangeOne[1]))
				{
					consumedPartnersCount++;
				}
			}

			return consumedPartnersCount;
		}
	}
}
