using Cignium.Searchfight.Website.SearchEngine.Bing;
using Cignium.Searchfight.Website.SearchEngine.Google;
using Cignium.Searchfight.Website.SearchEngine.Yahoo;
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
                var winners = new Dictionary<string, Tuple<string, long>>();

                var bingName = nameof(Bing);
                var googleName = nameof(Google);
                var yahooName = nameof(Yahoo);

                for (var i = 0; i < searchValues.Length; i++)
                {
                    var searchValue = searchValues[i];

                    Console.Write($"{searchValue}:");

                    // Bing
                    var bing = new Bing();
                    var bingResource = await bing.GetResource(searchValue);
                    var bingResultNumber = bing.GetResultNumber(bingResource);

                    Console.Write($" Bing: {bingResultNumber} ");

                    if (!winners.ContainsKey(bingName) || bingResultNumber > winners[bingName].Item2)
                    {
                        winners[bingName] = new Tuple<string, long>(searchValue, bingResultNumber);
                    }

                    // Google
                    var google = new Google();
                    var googleResource = await google.GetResource(searchValue);
                    var googleResultNumber = google.GetResultNumber(googleResource);

                    Console.Write($" Google: {googleResultNumber} ");

                    if (!winners.ContainsKey(googleName) || googleResultNumber > winners[googleName].Item2)
                    {
                        winners[googleName] = new Tuple<string, long>(searchValue, googleResultNumber);
                    }

                    // Yahoo
                    var yahoo = new Yahoo();
                    var yahooResource = await yahoo.GetResource(searchValue);
                    var yahooResultNumber = yahoo.GetResultNumber(yahooResource);

                    Console.Write($" Yahoo: {yahooResultNumber} ");

                    if (!winners.ContainsKey(yahooName) || yahooResultNumber > winners[yahooName].Item2)
                    {
                        winners[yahooName] = new Tuple<string, long>(searchValue, yahooResultNumber);
                    }

                    Console.Write("\r\n");
                }

                // Winner
                Console.Write($"Bing winner: {winners[bingName].Item1}\r\n");
                Console.Write($"Google winner: {winners[googleName].Item1}\r\n");
                Console.Write($"Yahoo winner: {winners[yahooName].Item1}\r\n");
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;

                Console.WriteLine($"\r\n{e.InnerException?.StackTrace ?? e.StackTrace}\r\n{e.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\r\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
