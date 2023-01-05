namespace AdventOfCode2022
{
    public class Day1
    {
        private readonly string _inputFile = "Input/Day_1_Input.txt";
        private readonly Elf _elfWithMostCalories;
        private readonly Elf[] _topElfsWithMostCalories;
        private readonly List<Elf> _elfs = new();

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
                        _elfs.Add(currentElf);
                        currentElf = new Elf();
                    }
                    else
                    {
                        currentElf.AddCalories(calories);
                    }
                }
                file.Close();
            }

            _elfWithMostCalories = Part1_GetElfWithMostCalories();
            Console.WriteLine($"Elf {_elfWithMostCalories.ElfNumber} has the most calories of {_elfWithMostCalories.Calories}");

            _topElfsWithMostCalories = Part2_GetTopThreeElfs();
            Console.WriteLine("\nThe top three elves with the most calories are:");
            foreach(var elf in _topElfsWithMostCalories)
            {
                Console.WriteLine($"Elf {elf.ElfNumber} with {elf.Calories} calories");
            }

            var topElvesCaloriesCombined = _topElfsWithMostCalories.Select(elf => elf.Calories).Sum();
            Console.WriteLine($"\nThe top three elves have a combined caloric content of: {topElvesCaloriesCombined} calories");
        }

        private Elf Part1_GetElfWithMostCalories()
        {
            Elf mostCaloricElf = _elfs[0];
            foreach (var elf in _elfs)
            {
                if (elf.Calories > mostCaloricElf.Calories)
                {
                    mostCaloricElf = elf;
                }
            }
            return mostCaloricElf;
        }

        private Elf[] Part2_GetTopThreeElfs()
        {
            return _elfs.OrderByDescending(elf => elf.Calories).Take(3).ToArray();
        }
    }

    public class Elf
    {
        private static int counter = 0;
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
