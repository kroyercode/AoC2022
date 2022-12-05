using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeFoundation.IO;

namespace AdventOfCodeFoundation.Solvers._2022
{
    [Solves("2022/12/3")]

    public class Day3Solver2022 : ISolver
    {
        private String lowercaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private String uppercaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public async Task<string> SolvePartOne(Input input)
        {
            var result = 0;
            var lines = await input.GetInputLines();
            foreach (var line in lines)
            {
                var firstHalf = line.Substring(0, line.Length / 2);
                var secondHalf = line.Substring(line.Length / 2);
                Console.WriteLine("line.length: " + line.Length);
                Console.WriteLine("first half: " + firstHalf + " length: " + firstHalf.Length);
                Console.WriteLine("second half: " + secondHalf + " length: " + secondHalf.Length);
                foreach (var letter in firstHalf)
                {
                    if (secondHalf.Contains(letter))
                    {
                        var charMapped = MapCharacterToValue(letter);
                        Console.WriteLine("Char mapped: " + letter + " -> " + charMapped);
                        result += charMapped;
                        break;
                    }
                }
                Console.WriteLine();

            }

            return result+"";

        }

      

        public async Task<string> SolvePartTwo(Input input)
        {
            var lines = input.GetInputLines().Result.ToArray();
            var result = 0;

            char vaerdiSat = Char.MaxValue;

            for (int i=0; i < lines.Count(); i=i+3)
            {
                var firstline = lines[i];
                var secondline = lines[i+1];
                var thirdline = lines[i+2];

                vaerdiSat = Char.MaxValue; //nul stil vaerdien

                foreach (var firstline_character in firstline)
                {
                    foreach (var secondline_character in secondline)
                    {
                        foreach (var thirdline_character in thirdline)
                        {
                            if (firstline_character == secondline_character && firstline_character == thirdline_character && vaerdiSat != firstline_character)
                            {
                                var charMapped = MapCharacterToValue(thirdline_character);
                                result += charMapped;
                                vaerdiSat = firstline_character;
                                break;
                            }
                        }
                    }
                }

            }

            return result+"";
        }

        private int MapCharacterToValue(char character)
        {
            for (int i = 0; i < lowercaseAlphabet.Length; i++)
            {
                if (character == lowercaseAlphabet[i])
                {
                    return i+1;
                }

            }

            var uppercaseCounter = 27;
            for (int i = 0; i < uppercaseAlphabet.Length; i++)
            {
                if (character == uppercaseAlphabet[i])
                {
                    return uppercaseCounter;
                }
                uppercaseCounter++;
            }


            throw new ArgumentException("Bru");
        }
    }
}
