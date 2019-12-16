using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model;
using Cignium.Searchfight.Website.SearchEngine.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.SearchEngine.Bing
{
    public class Bing : BaseSearchEngine, IBing
    {
        public Bing()
        {
            request = new Request()
            {
                Title = ConstantHelpers.Website.Bing.TITLE,
                Url = new Url()
                {
                    Host = ConstantHelpers.Website.Bing.Url.SearchEngine.HOST,
                    PathQuery = ConstantHelpers.Website.Bing.Url.SearchEngine.PATH_QUERY
                }
            };
        }

        public Bing(Request request)
        {
            this.request = request;
        }

        public async Task<string> GetApiResource(string searchValue)
        {
            var requestUriString = $"{request.Url.Host}{request.Url.PathQuery}{searchValue}";
            var webRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            webRequest.ContentType = ConstantHelpers.WebRequest.Api.CONTENT_TYPE;
            webRequest.Headers["Ocp-Apim-Trace"] = "true";
            webRequest.Headers["Ocp-Apim-Subscription-Key"] = ConstantHelpers.Api.Bing.Request.V7.KEY1;
            webRequest.Headers["UserAgent"] = ConstantHelpers.WebRequest.USER_AGENT;
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
    }
}
