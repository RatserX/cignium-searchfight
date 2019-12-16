using Cignium.Searchfight.Website.SearchEngine.Google;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cignium.Searchfight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var searchValues = new string[]
            {
                ".net",
                "java",
                "java script"
            };

            try
            {
                var consoleValue = "";
                var winners = new Dictionary<string, Tuple<string, long>>();
                var googleName = nameof(Google);

                for (var i = 0; i < searchValues.Length; i++)
                {
                    var searchValue = searchValues[i];

                    // Google
                    var google = new Google();
                    var resource = await google.GetResource(searchValue);
                    var resultNumber = google.GetResultNumber(resource);

                    consoleValue += $"{searchValue}: ";
                    consoleValue += $"Google: {resultNumber}";

                    if (!winners.ContainsKey(googleName) || resultNumber > winners[googleName].Item2)
                    {
                        winners[googleName] = new Tuple<string, long>(searchValue, resultNumber);
                    }

                    consoleValue += "\n\r";
                }

                // Winner
                consoleValue += $"Google winner: {winners[googleName].Item1}";

                consoleValue += "\n\r";

                Console.WriteLine(consoleValue);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.InnerException?.StackTrace ?? e.StackTrace}\r\n{e.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
