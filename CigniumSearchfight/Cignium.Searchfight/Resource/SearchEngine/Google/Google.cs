using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model;
using Cignium.Searchfight.Website.SearchEngine.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.SearchEngine.Google
{
    public class Google : BaseSearchEngine, IGoogle
    {
        public Google()
        {
            request = new Request()
            {
                Title = ConstantHelpers.Website.Google.TITLE,
                Url = new Url()
                {
                    Host = ConstantHelpers.Website.Google.Url.SearchEngine.HOST,
                    PathQuery = ConstantHelpers.Website.Google.Url.SearchEngine.PATH_QUERY
                }
            };
        }

        public Google(Request request)
        {
            this.request = request;
        }

        public async Task<string> GetApiResource(string searchValue)
        {
            var requestUriString = $"{request.Url.Host}{request.Url.PathQuery}{ConstantHelpers.Api.Google.Request.KEY}&cx=017576662512468239146:omuauf_lfve&q={searchValue}";
            var webRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            webRequest.ContentType = ConstantHelpers.WebRequest.Api.CONTENT_TYPE;
            webRequest.Timeout = ConstantHelpers.WebRequest.TIMEOUT;

            using (var response = await webRequest.GetResponseAsync())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        return await streamReader.ReadToEndAsync();
                    }
                }
            }
        }

        public long GetResultNumber(string input, string pattern = ConstantHelpers.Website.Google.Resource.ResultNumber.REGEX_PATTERN)
        {
            var regexGroup = input.RegexGroup(pattern);

            if (regexGroup == null)
            {
                throw new Exception(ErrorHelper.GetRegexGroupEmptyError());
            }

            var valueSplit = regexGroup.Value.Split(ConstantHelpers.Website.Google.Resource.ResultNumber.SPLIT_SEPARATOR);

            for (var i = 0; i < valueSplit.Length; i++)
            {
                if (valueSplit[i].TryToLong(out long result))
                {
                    return result;
                }
            }

            return 0;
        }

        public TimeSpan GetResultTime(string input, string pattern = ConstantHelpers.Website.Google.Resource.ResultTime.REGEX_PATTERN)
        {
            var regexGroup = input.RegexGroup(pattern);
            var resultTimeSplit = regexGroup.Value.Split(ConstantHelpers.Website.Google.Resource.ResultTime.SPLIT_SEPARATOR);

            for (var i = 0; i < resultTimeSplit.Length; i++)
            {
                if (resultTimeSplit[i].TryToDouble(out double result))
                {
                    return TimeSpan.FromSeconds(result);
                }
            }

            return TimeSpan.FromSeconds(0);
        }
    }
}
