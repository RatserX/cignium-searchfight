using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model;
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
        private static readonly string bingName = nameof(Bing);
        private static readonly string googleName = nameof(Google);
        private static readonly string yahooName = nameof(Yahoo);

        private static Dictionary<string, Tuple<string, long>> winners = new Dictionary<string, Tuple<string, long>>();

        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            string[] searchValues = args;

            try
            {
                if (GeneralHelpers.IsDebug())
                {
                    searchValues = new string[]
                    {
                        ".net",
                        "java",
                        "java script"
                    };
                }

                if (searchValues.Length <= 0)
                {
                    Console.Write("\r\nUsage: Cignium.Searchfight.exe search_queries\r\n");
                    return;
                }

                // Search Engines

                for (var i = 0; i < searchValues.Length; i++)
                {
                    var searchValue = searchValues[i];

                    Console.Write($"{searchValue}:");

                    await BingSearch(searchValue);
                    await GoogleSearch(searchValue);
                    await YahooSearch(searchValue);

                    Console.Write("\r\n");
                }

                Console.Write("\r\n");

                // Winners

                Console.Write($"Bing winner: {winners[bingName].Item1}\r\n");
                Console.Write($"Google winner: {winners[googleName].Item1}\r\n");
                Console.Write($"Yahoo winner: {winners[yahooName].Item1}\r\n");

                Console.Write("\r\n");

                // Total Winner

                var totalWinnerResultNumber = 0L;
                var totalWinnerSearchValue = "";

                foreach (var value in winners.Values)
                {
                    var resultNumber = value.Item2;
                    var searchValue = value.Item1;

                    if (resultNumber > totalWinnerResultNumber)
                    {
                        totalWinnerResultNumber = resultNumber;
                        totalWinnerSearchValue = searchValue;
                    }
                }

                Console.Write($"Total winner: {totalWinnerSearchValue}\r\n");
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

        private static async Task BingSearch(string searchValue)
        {
            var resource = "";
            var resultNumber = 0L;

            if (!ConstantHelpers.General.USE_API)
            {
                var bing = new Bing();
                resource = await bing.GetDefaultResource(searchValue);

                resource.TryToLong(out resultNumber, ConstantHelpers.Website.Bing.Resource.ResultNumber.REGEX_PATTERN, ConstantHelpers.Website.Bing.Resource.ResultNumber.SPLIT_SEPARATOR);
            }
            else
            {
                var bing = new Bing(new Request()
                {
                    Url = new Url()
                    {
                        Host = ConstantHelpers.Api.Bing.Url.BingSearchV7.HOST,
                        PathQuery = ConstantHelpers.Api.Bing.Url.BingSearchV7.PATH_QUERY
                    }
                });
                resource = await bing.GetApiResource(searchValue);

                resource.TryToLong(out resultNumber, ConstantHelpers.Api.Bing.Result.ResultNumber.REGEX_PATTERN);
            }

            Console.Write($" Bing: {resultNumber}");

            if (!winners.ContainsKey(bingName) || resultNumber > winners[bingName].Item2)
            {
                winners[bingName] = new Tuple<string, long>(searchValue, resultNumber);
            }
        }

        public static async Task GoogleSearch(string searchValue)
        {
            var resource = "";
            var resultNumber = 0L;

            var google = new Google();
            resource = await google.GetDefaultResource(searchValue);

            resource.TryToLong(out resultNumber, ConstantHelpers.Website.Google.Resource.ResultNumber.REGEX_PATTERN, ConstantHelpers.Website.Google.Resource.ResultNumber.SPLIT_SEPARATOR);

            /*if (!ConstantHelpers.General.USE_API)
            {
                // This is against the Google ToS but it's the most accurate way to obtain the total results number.
                // https://policies.google.com/terms?gl=US&hl=en

                var google = new Google();
                resource = await google.GetDefaultResource(searchValue);

                resource.TryToLong(out resultNumber, ConstantHelpers.Website.Google.Resource.ResultNumber.REGEX_PATTERN, ConstantHelpers.Website.Google.Resource.ResultNumber.SPLIT_SEPARATOR);
            }
            else
            {
                // The Google Custom Search API does NOT returns the total results number of all pages combined,
                // just the total results number of the current page.

                var google = new Google(new Request()
                {
                    Url = new Url()
                    {
                        Host = ConstantHelpers.Api.Google.Url.CustomSearch.HOST,
                        PathQuery = ConstantHelpers.Api.Google.Url.CustomSearch.PATH_QUERY
                    }
                });
                resource = await google.GetApiResource(searchValue);

                resource.TryToLong(out resultNumber, ConstantHelpers.Api.Google.Result.ResultNumber.REGEX_PATTERN);
            }*/

            Console.Write($" Google: {resultNumber}");

            if (!winners.ContainsKey(googleName) || resultNumber > winners[googleName].Item2)
            {
                winners[googleName] = new Tuple<string, long>(searchValue, resultNumber);
            }
        }

        public static async Task YahooSearch(string searchValue)
        {
            var resource = "";
            var resultNumber = 0L;

            var yahoo = new Yahoo();
            resource = await yahoo.GetDefaultResource(searchValue);

            resource.TryToLong(out resultNumber, ConstantHelpers.Website.Yahoo.Resource.ResultNumber.REGEX_PATTERN, ConstantHelpers.Website.Yahoo.Resource.ResultNumber.SPLIT_SEPARATOR);

            /*if (!ConstantHelpers.General.USE_API)
            {
                var yahoo = new Yahoo();
                resource = await yahoo.GetDefaultResource(searchValue);

                resource.TryToLong(out resultNumber, ConstantHelpers.Website.Yahoo.Resource.ResultNumber.REGEX_PATTERN, ConstantHelpers.Website.Google.Resource.ResultNumber.SPLIT_SEPARATOR);
            }
            else
            {
                // As of January 3, 2019, Yahoo has discontinued its YQL service. Therefore, it's not
                // possible to obtain the search results using its API.
                // https://twitter.com/ydn/status/1079785891558653952?lang=es

                var yahoo = new Yahoo(new Request()
                {
                    Url = new Url()
                    {
                        Host = ConstantHelpers.Api.Yahoo.Url.WebSearchService.HOST,
                        PathQuery = ConstantHelpers.Api.Yahoo.Url.WebSearchService.PATH_QUERY
                    }
                });
                resource = await yahoo.GetDefaultResource(searchValue);

                resource.TryToLong(out resultNumber, ConstantHelpers.Api.Yahoo.Result.ResultNumber.REGEX_PATTERN);
            }*/

            Console.Write($" Yahoo: {resultNumber}");

            if (!winners.ContainsKey(yahooName) || resultNumber > winners[yahooName].Item2)
            {
                winners[yahooName] = new Tuple<string, long>(searchValue, resultNumber);
            }
        }
    }
}
