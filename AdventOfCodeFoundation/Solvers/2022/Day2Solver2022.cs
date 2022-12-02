using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeFoundation.IO;

namespace AdventOfCodeFoundation.Solvers._2022
{
    [Solves("2022/12/2")]

    public class Day2Solver2022 : ISolver
    {
        public async Task<string> SolvePartOne(Input input)
        {
            var lines = await input.GetInputLines();

            /*
             * A = Rock
             * B = Paper
             * C = Scissors
             *
             * X = Rock
             * Y = Paper
             * Z = Scissors
             */

            var totalScore = Matchsolver(lines);

            return totalScore+"";

        }

        private static int Matchsolver(IEnumerable<string> lines)
        {
            var totalScore = 0;

            foreach (var line in lines)
            {
                switch (line)
                {
                    case "A X":
                        totalScore += 1 + 3;
                        break;
                    case "A Y":
                        totalScore += 2 + 6;
                        break;
                    case "A Z":
                        totalScore += 3 + 0;
                        break;
                    case "B X":
                        totalScore += 1 + 0;
                        break;
                    case "B Y":
                        totalScore += 2 + 3;
                        break;
                    case "B Z":
                        totalScore += 3 + 6;
                        break;
                    case "C X":
                        totalScore += 1 + 6;
                        break;
                    case "C Y":
                        totalScore += 2 + 0;
                        break;
                    case "C Z":
                        totalScore += 3 + 3;
                        break;
                    default:
                        throw new Exception("bro");
                }
            }

            return totalScore;
        }

        public async Task<string> SolvePartTwo(Input input)
        {
            var lines = await input.GetInputLines();

            /*
             * A = Rock
             * B = Paper
             * C = Scissors
             *
             * X = Rock
             * Y = Paper
             * Z = Scissors
             */
            var newLines = new List<string>();

            foreach (var line in lines)
            {
                var newline = "";
                switch (line)
                {
                    case "A X":
                        newline = "A Z";
                        newLines.Add(newline);
                        break;
                    case "A Y":
                        newline = "A X";
                        newLines.Add(newline);
                        break;
                    case "A Z":
                        newline = "A Y";
                        newLines.Add(newline);
                        break;
                    case "B X":
                        newline = "B X";
                        newLines.Add(newline);
                        break;
                    case "B Y":
                        newline = "B Y";
                        newLines.Add(newline);
                        break;
                    case "B Z":
                        newline = "B Z";
                        newLines.Add(newline);
                        break;
                    case "C X":
                        newline = "C Y";
                        newLines.Add(newline);
                        break;
                    case "C Y":
                        newline = "C Z";
                        newLines.Add(newline);
                        break;
                    case "C Z":
                        newline = "C X";
                        newLines.Add(newline);
                        break;
                    default:
                        throw new Exception("bro");
                }

            }

            var totalscore = Matchsolver(newLines);
            return totalscore + "";

        }
    }
}
