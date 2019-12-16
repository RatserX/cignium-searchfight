using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Core.Helper
{
    public class ConstantHelpers
    {
        public static class General
        {
            public const bool USE_API = false;
        }

        public static class WebRequest
        {
            public static class SearchEngine
            {
                public const string CONTENT_TYPE = "application/x-www-form-urlencoded";
                public const int TIMEOUT = 10000;
                public const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
            }
        }

        public static class Website
        {
            public static class Bing
            {
                public const string TITLE = "Bing";

                public static class Api
                {
                    public const string KEY = "";
                }

                public static class Resource
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:<span)(?:[^>]*)(?:class=\""sb_count\"")(?:[^>]*)(?:>)(.*)(?:<span>)";
                        public const int SPLIT_INDEX = 2;
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

                public static class Api
                {
                    public const string KEY = "";
                }

                public static class Resource
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:id=\""resultStats\"")(?:[^>]*)(?:>)(.*)(?:<nobr>)";
                        public const int SPLIT_INDEX = 2;
                        public const string SPLIT_SEPARATOR = " ";
                    }

                    public static class ResultTime
                    {
                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:id=\""resultStats\"")(?:[^>]*)(?:>)(?:.*)(?:<nobr>)(.*)(?:</nobr>)";
                        public const int SPLIT_INDEX = 1;
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

                public static class Api
                {
                    public const string KEY = "";
                }

                public static class Resource
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:class=\""compPagination\"")(?:[^>]*)(?:id=\""yui)(?:[^>]*)(?:<span)(?:[^>]*)(?:id=\""yui)(?:[^>]*)(?:>)(.*)(?:<\/span>)";
                        public const int SPLIT_INDEX = 2;
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
