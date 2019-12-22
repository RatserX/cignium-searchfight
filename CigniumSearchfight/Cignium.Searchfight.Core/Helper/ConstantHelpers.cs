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

                public static class Response
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:\""totalEstimatedMatches\"": )(.*?)(?:,)";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class BingSearch
                    {
                        public const string SEARCH = "https://api.cognitive.microsoft.com/bing/v5.0/search";
                        //public const string PATH_QUERY = "bing/v5.0/search/?q=";
                    }

                    public static class BingSearchV7
                    {
                        public const string SEARCH = "https://api.cognitive.microsoft.com/bing/v7.0/search";
                        //public const string PATH_QUERY = "bing/v7.0/search/?q=";
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

                public static class Response
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:\""totalResults\"": )(.*?)(?:,)";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class CustomSearch
                    {
                        public const string CUSTOMSEARCH = "https://www.googleapis.com/customsearch/v1";
                        //public const string PATH_QUERY = "customsearch/v1?key=";
                    }
                }
            }

            public static class Yahoo
            {
                public static class Request
                {
                    // The API information should not be commited to the repository, but this is just an example.
                    public const string KEY = "";
                }

                public static class Response
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = "";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class WebSearchService
                    {
                        public const string WEB_SEARCH = "http://search.yahooapis.com/WebSearchService/V1/webSearch";
                        //public const string PATH_QUERY = "WebSearchService/V1/webSearch?";
                    }
                }
            }
        }

        public static class General
        {
            public const int PREFERRED_OPERATION = Operation.HTTP;
        }

        public static class Error
        {
            public const string REGEX_GROUP_EMPTY = "Regex group is empty";
        }

        public static class Operation
        {
            public const int API = 1;
            public const int HTTP = 2;
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

        public static class Http
        {
            public static class Bing
            {
                public static class Response
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
                        public const string SEARCH = "https://www.bing.com/search";
                    }
                }
            }

            public static class Google
            {
                public static class Response
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
                        public const string SEARCH = "https://www.google.com/search";
                        //public const string PATH_QUERY = "search?q=";
                    }
                }
            }

            public static class Yahoo
            {
                public static class Response
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
                        public const string SEARCH = "https://search.yahoo.com/search";
                        //public const string PATH_QUERY = "search?p=";
                    }
                }
            }
        }
    }
}
