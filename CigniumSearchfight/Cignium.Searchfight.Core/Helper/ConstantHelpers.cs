using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Core.Helper
{
    public class ConstantHelpers
    {
        public static class Api
        {
            public static class Bing
            {
                public static class Request
                {
                    // The API information should not be commited to the repository, but this is just an example.
                    public static class Default
                    {
                        public const string KEY1 = "f85510efc9fd4f0389c939d0b895f3a5";
                        public const string KEY2 = "ee2238cd70344980bbc40ca1683ddc04";
                    }

                    public static class V7
                    {
                        public const string KEY1 = "01bcb3ddeb7c4e4294ea485fedf11e3e";
                        public const string KEY2 = "41db6336ceef4f60b7e2d5b1df4688e7";
                    }
                }

                public static class Result
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:\""totalEstimatedMatches\"": )(.*?)(?:,)";
                    }
                }

                public static class Url
                {
                    public static class BingSearch
                    {
                        public const string HOST = "https://api.cognitive.microsoft.com/";
                        public const string PATH_QUERY = "bing/v5.0/search/?q=";
                    }

                    public static class BingSearchV7
                    {
                        public const string HOST = "https://api.cognitive.microsoft.com/";
                        public const string PATH_QUERY = "bing/v7.0/search/?q=";
                    }
                }
            }

            public static class Google
            {
                public static class Request
                {
                    // The API information should not be commited to the repository, but this is just an example.
                    public const string KEY = "AIzaSyAUSWtPHqKVSpnr4cB04WMptqIO_5-0A5k";
                }

                public static class Result
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:\""totalResults\"": )(.*?)(?:,)";
                    }
                }

                public static class Url
                {
                    public static class CustomSearch
                    {
                        public const string HOST = "https://www.googleapis.com/";
                        public const string PATH_QUERY = "customsearch/v1?key=";
                    }
                }
            }

            public static class Yahoo
            {
                public static class Request
                {
                    // The API information should not be commited to the repository, but this is just an example.
                    public const string KEY = "AIzaSyAUSWtPHqKVSpnr4cB04WMptqIO_5-0A5k";
                }

                public static class Url
                {
                    public static class WebSearchService
                    {
                        public const string HOST = "http://search.yahooapis.com/";
                        public const string PATH_QUERY = "WebSearchService/V1/webSearch?";
                    }
                }
            }
        }

        public static class General
        {
            public const bool USE_API = false;
        }

        public static class Error
        {
            public const string REGEX_GROUP_EMPTY = "Regex group is empty";
        }

        public static class WebRequest
        {
            public const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
            public const int TIMEOUT = 10000;

            public static class Api
            {
                public const string CONTENT_TYPE = "application/json";
            }

            public static class Default
            {
                public const string CONTENT_TYPE = "application/x-www-form-urlencoded";
            }
        }

        public static class Website
        {
            public static class Bing
            {
                public const string TITLE = "Bing";

                public static class Resource
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:<span)(?:[^>]*)(?:class=\""sb_count\"")(?:[^>]*)(?:>)(.*?)(?:</span>)";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class SearchEngine
                    {
                        public const string HOST = "https://www.bing.com/";
                        public const string PATH_QUERY = "search?q=";
                    }
                }
            }

            public static class Google
            {
                public const string TITLE = "Google";

                public static class Resource
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:id=\""resultStats\"")(?:[^>]*)(?:>)(.*?)(?:<nobr>)";
                        public const string SPLIT_SEPARATOR = " ";
                    }

                    public static class ResultTime
                    {
                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:id=\""resultStats\"")(?:[^>]*)(?:>)(?:.*)(?:<nobr>)(.*?)(?:</nobr>)";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class SearchEngine
                    {
                        public const string HOST = "https://www.google.com/";
                        public const string PATH_QUERY = "search?q=";
                    }
                }
            }

            public static class Yahoo
            {
                public const string TITLE = "Yahoo";

                public static class Resource
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:class=\""compPagination\"")(?:.*?)(?:<span)(?:[^>]*)(?:>)(.*?)(?:</span>)";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class SearchEngine
                    {
                        public const string HOST = "https://search.yahoo.com/";
                        public const string PATH_QUERY = "search?p=";
                    }
                }
            }
        }
    }
}
