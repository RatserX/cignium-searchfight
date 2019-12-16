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
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            string[] searchValues;

            try
            {
#if DEBUG
                searchValues = new string[]
                {
                    ".net",
                    "java",
                    "java script"
                };
#else
                searchValues = args;
#endif

                if (searchValues.Length <= 0)
                {
                    Console.Write("\r\nUsage: Cignium.Searchfight.exe search_queries\r\n");
                    return;
                }

                var winners = new Dictionary<string, Tuple<string, long>>();

                var bingName = nameof(Bing);
                var googleName = nameof(Google);
                var yahooName = nameof(Yahoo);

                for (var i = 0; i < searchValues.Length; i++)
                {
                    string bingResource, googleResource, yahooResource;
                    long bingResultNumber, googleResultNumber, yahooResultNumber;
                    var searchValue = searchValues[i];

                    Console.Write($"{searchValue}:");

                    // Bing

                    if (!ConstantHelpers.General.USE_API)
                    {
                        var bing = new Bing();
                        bingResource = await bing.GetDefaultResource(searchValue);
                        bingResultNumber = bing.GetResultNumber(bingResource);
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
                        bingResource = await bing.GetApiResource(searchValue);
                        bingResultNumber = bing.GetResultNumber(bingResource, ConstantHelpers.Api.Bing.Result.ResultNumber.REGEX_PATTERN);
                    }

                    Console.Write($" Bing: {bingResultNumber}");

                    if (!winners.ContainsKey(bingName) || bingResultNumber > winners[bingName].Item2)
                    {
                        winners[bingName] = new Tuple<string, long>(searchValue, bingResultNumber);
                    }

                    // Google

                    var google = new Google();
                    googleResource = await google.GetDefaultResource(searchValue);
                    googleResultNumber = google.GetResultNumber(googleResource);

                    /*if (!ConstantHelpers.General.USE_API)
                    {
                        // This is against the Google ToS but it's the most accurate way to obtain the total results number.
                        // https://policies.google.com/terms?gl=US&hl=en

                        var google = new Google();
                        googleResource = await google.GetDefaultResource(searchValue);
                        googleResultNumber = google.GetResultNumber(googleResource);
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
                        googleResource = await google.GetApiResource(searchValue);
                        googleResultNumber = google.GetResultNumber(googleResource, ConstantHelpers.Api.Google.Result.ResultNumber.REGEX_PATTERN);
                    }*/

                    Console.Write($" Google: {googleResultNumber}");

                    if (!winners.ContainsKey(googleName) || googleResultNumber > winners[googleName].Item2)
                    {
                        winners[googleName] = new Tuple<string, long>(searchValue, googleResultNumber);
                    }

                    // Yahoo
                    var yahoo = new Yahoo();
                    yahooResource = await yahoo.GetDefaultResource(searchValue);
                    yahooResultNumber = yahoo.GetResultNumber(yahooResource);

                    /*if (!ConstantHelpers.General.USE_API)
                    {
                        var yahoo = new Yahoo();
                        yahooResource = await yahoo.GetDefaultResource(searchValue);
                        yahooResultNumber = yahoo.GetResultNumber(yahooResource);
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
                        yahooResource = await yahoo.GetDefaultResource(searchValue);
                        yahooResultNumber = yahoo.GetResultNumber(yahooResource);
                    }*/

                    Console.Write($" Yahoo: {yahooResultNumber}");

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
