using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model.SearchEngine;
using Cignium.Searchfight.Web.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Web.SearchEngine.Base
{
    public abstract class BaseSearchEngine : BaseWeb, IBaseSearchEngine
    {
        protected Result currentResult;
        protected Result topResult;

        public BaseSearchEngine()
        {
            currentResult = new Result();
            topResult = new Result();
        }

        public Result GetCurrentResult()
        {
            return currentResult;
        }

        public Result GetTopResult()
        {
            return topResult;
        }

        public void LoadResultNumber(string regexPattern, string splitSeparator = " ")
        {
            var responseCharacters = response.Characters.ToString();

            responseCharacters.TryToLong(out long resultNumber, regexPattern, splitSeparator);

            currentResult.Number = resultNumber;

            if (resultNumber > topResult.Number)
            {
                topResult = currentResult;
            }
        }

        public void LoadResultTime(string regexPattern, string splitSeparator = " ")
        {
            var responseCharacters = response.Characters.ToString();

            responseCharacters.TryToSeconds(out TimeSpan resultTime, regexPattern, splitSeparator);

            currentResult.Time = resultTime;
        }

        public async Task LoadHttpResponse(Uri uri)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = ConstantHelpers.WebRequest.Default.CONTENT_TYPE;
            httpWebRequest.UserAgent = ConstantHelpers.WebRequest.USER_AGENT;
            httpWebRequest.Timeout = ConstantHelpers.WebRequest.TIMEOUT;

            await LoadResponse(httpWebRequest);
        }
    }
}
