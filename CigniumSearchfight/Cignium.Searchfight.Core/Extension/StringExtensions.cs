using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cignium.Searchfight.Core.Extension
{
    public static class StringExtensions
    {
        public static double ToDouble(this string input)
        {
            var regex = new Regex("[^0-9.]");
            var s = regex.Replace(input, "");

            return double.Parse(s);
        }

        public static long ToLong(this string input)
        {
            var regex = new Regex("[^0-9]");
            var s = regex.Replace(input, "");

            return long.Parse(s);
        }
        public static bool TryToDouble(this string input, out double result)
        {
            var regex = new Regex("[^0-9.]");
            var s = regex.Replace(input, "");

            return double.TryParse(s, out result);
        }

        public static bool TryToLong(this string input, out long result)
        {
            var regex = new Regex("[^0-9]");
            var s = regex.Replace(input, "");

            return long.TryParse(s, out result);
        }

        public static Group RegexGroup(this string input, string pattern)
        {
            var regex = new Regex(pattern);

            if (regex.IsMatch(input))
            {
                var match = regex.Match(input);
                var groups = match.Groups;

                if (groups.Count >= 2)
                {
                    return groups[1];
                }
            }

            return null;
        }

        public static string SplitValue(this string input, string separator, int index, StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            var inputSplit = input.Split(separator, stringSplitOptions);
            var inputSplitValue = inputSplit[index];

            return inputSplitValue;
        }
    }
}
