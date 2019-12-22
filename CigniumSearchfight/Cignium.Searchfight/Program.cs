using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model;
using Cignium.Searchfight.Core.Model.SearchEngine;
using Cignium.Searchfight.Web.SearchEngine.Base;
using Cignium.Searchfight.Web.SearchEngine.Bing;
using Cignium.Searchfight.Web.SearchEngine.Google;
using Cignium.Searchfight.Web.SearchEngine.Yahoo;
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
                var bing = new Bing();
                var google = new Google();
                var yahoo = new Yahoo();

                var baseSearchEngines = new BaseSearchEngine[]
                {
                    bing,
                    google,
                    yahoo
                };

                for (var i = 0; i < searchValues.Length; i++)
                {
                    var searchValue = searchValues[i];

                    Console.Write($"{searchValue}:");

                    await bing.LoadResponseBySearchValue(searchValue);
                    await google.LoadResponseBySearchValue(searchValue);
                    await yahoo.LoadResponseBySearchValue(searchValue);

                    // Bing
                    bing.LoadResultNumber();

                    // Google
                    google.LoadResultNumber();
                    google.LoadResultTime();

                    // Yahoo
                    yahoo.LoadResultNumber();

                    for (var j = 0; j < baseSearchEngines.Length; j++)
                    {
                        var baseSearchEngine = baseSearchEngines[j];
                        var currentResult = baseSearchEngine.GetCurrentResult();
                        var request = baseSearchEngine.GetRequest();

                        Console.Write($" {request.Title}: {currentResult.Number} ({currentResult.Time.TotalSeconds}s)");
                    }

                    Console.Write("\r\n");
                }

                Result totalTopResult = null;

                for (var i = 0; i < baseSearchEngines.Length; i++)
                {
                    var baseSearchEngine = baseSearchEngines[i];
                    var topResult = baseSearchEngine.GetTopResult();
                    var request = baseSearchEngine.GetRequest();

                    if (totalTopResult == null || totalTopResult.Number < topResult.Number)
                    {
                        totalTopResult = topResult;
                    }

                    Console.Write($"{request.Title} winner: {topResult.Text}");
                    Console.Write("\r\n");
                }

                Console.Write($"Total winner: {totalTopResult.Text}\r\n");
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
