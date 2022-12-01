using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeFoundation.IO;

namespace AdventOfCodeFoundation.Solvers._2022
{
    [Solves("2022/12/1")]

    public class Day1Solver2022 : ISolver
    {
        public async Task<string> SolvePartOne(Input input)
        {
            var lines = await input.GetInputLines();

            var currentMax = -99;
            var sumPrElf = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (sumPrElf > currentMax)
                    {
                        currentMax = sumPrElf;
                    }
                    sumPrElf = 0;
                    continue;
                }

                sumPrElf += Int32.Parse(line);
            }

            return currentMax+"";

        }

        public async Task<string> SolvePartTwo(Input input)
        {

            var lines = await input.GetInputLines();

            var sumPrElf = 0;
            var liste = new List<int>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    liste.Add(sumPrElf);
                    sumPrElf = 0;
                    continue;
                }

                sumPrElf += Int32.Parse(line);
            }

            liste.Sort();
            var result = liste[liste.Count - 1] + liste[liste.Count - 2] + liste[liste.Count - 3]+"";
            return result;

        }
    }
}
