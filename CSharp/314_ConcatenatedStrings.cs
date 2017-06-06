using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
{
    /// <summary>
    /// Given a list of integers separated by a single space on standard input, print out the largest and smallest values that can be obtained by concatenating the integers together on their own line. 
    /// This is from Five programming problems every Software Engineer should be able to solve in less than 1 hour, problem 4. 
    /// Leading 0s are not allowed (e.g. 01234 is not a valid entry).
    /// </summary>
    /// <see cref="https://www.reddit.com/r/dailyprogrammer/comments/69y21t/20170508_challenge_314_easy_concatenated_integers/"/>
    public static class ConcatenatedStrings
    {
        public static (long smallest, long largest) Get(string input)
        {
            var integers = input
                .Split(' ')
                .SortStringIntegers()
                .Select(int.Parse);

            return (
                smallest: long.Parse(integers.Select(x => $"{x}").Aggregate(string.Empty, (x, y) => $"{x}{y}")),
                largest: long.Parse(integers.Reverse().Select(x => $"{x}").Aggregate(string.Empty, (x, y) => $"{x}{y}")));
        }

        public static IEnumerable<string> SortStringIntegers(this IEnumerable<string> input)
        {
            var sorted = input.ToList();
            sorted.Sort((x, y) =>
            {
                int one = int.Parse(x + y);
                int two = int.Parse(y + x);

                if (one == two) return 0;

                return (one > two) ? 1 : -1;
            });

            return sorted;
        }
    }
}