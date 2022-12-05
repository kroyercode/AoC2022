using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeFoundation.IO;

namespace AdventOfCodeFoundation.Solvers._2022
{
    [Solves("2022/12/4")]

    public class Day4Solver2022 : ISolver
    {

        public async Task<string> SolvePartOne(Input input)
        {
            var lines = await input.GetInputLines();
            int result = 0;

            foreach (var line in lines)
            {
                var splittedLine = line.Split(',');
                var firstElf = splittedLine[0];
                var secondElf = splittedLine[1];

                var firstElfRooms = firstElf.Split("-");
                var firstElfStart = Int32.Parse(firstElfRooms[0]);
                var firstElfEnd = Int32.Parse(firstElfRooms[1]);

                var secondElfRooms = secondElf.Split("-");
                var secondElfStart = Int32.Parse(secondElfRooms[0]);
                var secondElfEnd = Int32.Parse(secondElfRooms[1]);


                //Hvis den anden elf ikke skal arbejde (han er totalt overlappet af første elf)
                if (firstElfStart <= secondElfStart && firstElfEnd >= secondElfEnd)
                {
                    result++;
                    continue;
                }

                //Hvis den første elf ikke skal arbejde (han er totalt overlappet af anden elf)
                if (secondElfStart <= firstElfStart && secondElfEnd >= firstElfEnd)
                {
                    result++;
                    continue;
                }

            }

            return result+"";

        }

        public async Task<string> SolvePartTwo(Input input)
        {
            var lines = await input.GetInputLines();
            int result = 0;

            foreach (var line in lines)
            {
                var splittedLine = line.Split(',');
                var firstElf = splittedLine[0];
                var secondElf = splittedLine[1];

                var firstElfRooms = firstElf.Split("-");
                var firstElfStart = Int32.Parse(firstElfRooms[0]);
                var firstElfEnd = Int32.Parse(firstElfRooms[1]);

                var secondElfRooms = secondElf.Split("-");
                var secondElfStart = Int32.Parse(secondElfRooms[0]);
                var secondElfEnd = Int32.Parse(secondElfRooms[1]);

                if (firstElfStart <= secondElfStart && firstElfEnd >= secondElfStart)
                {
                    result++;
                    continue;
                }

                if (firstElfStart >= secondElfStart && firstElfEnd >= secondElfEnd )
                {
                    result++;
                    continue;
                }

            }

            return result + "";
        }
    }
}
