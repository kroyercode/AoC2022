using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeFoundation.IO;

namespace AdventOfCodeFoundation.Solvers._2022
{
    [Solves("2022/12/5")]

    public class Day5Solver2022 : ISolver
    {

        public async Task<string> SolvePartOne(Input input)
        {
            var lines = await input.GetInputLines();

            List<List<string>> stacks = new List<List<string>>(200);
            InitStacks(stacks);

            foreach (var line in lines)
            {
                var splittedline = line.Trim().Split(' ');
                if (splittedline[0] == "1") break;
                for (int i=0; i<splittedline.Length; i++)
                {
                    var bogstav = splittedline[i];
                    if (bogstav == "[0]")
                    {
                        continue;
                    }
                    else
                    {
                        stacks[i+1].Add(bogstav);
                    }
                }
            }

            foreach (var line in lines)
            {
                if (line.StartsWith("move"))
                {
                    var splitted = line.Trim().Split(' ');
                    var times = int.Parse(splitted[1]);
                    var from = int.Parse(splitted[3]);
                    var to = int.Parse(splitted[5]);
                    MoveStacks(stacks, times, from, to);

                }
            }

            var result = "";
            for (int i=0; i<stacks.Count; i++)
            {
                result = result + stacks[i].FirstOrDefault();
            }

            return result;

        }

        private void MoveStacks(List<List<string>> stacks, int times, int from, int to)
        {
            for (int i = 0; i < times; i++)
            {
                var crate = stacks[from].First();
                stacks[from].Remove(crate);
                stacks[to].Insert(0,crate);
            }
        }

        private static void InitStacks(List<List<string>> stacks)
        {
            for (int i = 0; i < 200; i++)
            {
                stacks.Add(new List<string>());
            }
        }


        public async Task<string> SolvePartTwo(Input input)
        {
            var lines = await input.GetInputLines();

            List<List<string>> stacks = new List<List<string>>(200);
            InitStacks(stacks);

            foreach (var line in lines)
            {
                var splittedline = line.Trim().Split(' ');
                if (splittedline[0] == "1") break;
                for (int i = 0; i < splittedline.Length; i++)
                {
                    var bogstav = splittedline[i];
                    if (bogstav == "[0]")
                    {
                        continue;
                    }
                    else
                    {
                        stacks[i + 1].Add(bogstav);
                    }
                }
            }

            foreach (var line in lines)
            {
                if (line.StartsWith("move"))
                {
                    var splitted = line.Trim().Split(' ');
                    var times = int.Parse(splitted[1]);
                    var from = int.Parse(splitted[3]);
                    var to = int.Parse(splitted[5]);
                    MoveMultipleStacks(stacks, times, from, to);

                }
            }

            var result = "";
            for (int i = 0; i < stacks.Count; i++)
            {
                result = result + stacks[i].FirstOrDefault();
            }

            return result;
        }

        private void MoveMultipleStacks(List<List<string>> stacks, int times, int from, int to)
        {
            var tempList = new List<string>();

            for (int i = 0; i < times; i++)
            {
                var crate = stacks[from].First();
                stacks[from].Remove(crate);

                tempList.Add(crate);

            }


            stacks[to] = tempList.Concat(stacks[to]).ToList();

        }
    }
}
