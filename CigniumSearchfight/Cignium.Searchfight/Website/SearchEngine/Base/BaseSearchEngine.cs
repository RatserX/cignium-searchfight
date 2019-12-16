using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Website.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.SearchEngine.Base
{
    public class BaseSearchEngine : BaseWebsite, IBaseSearchEngine
    {
        public BaseSearchEngine()
        {

        }

        public async Task<string> GetResource(string searchValue)
        {
            var requestUriString = $"{website.Url.Host}{website.Url.PathQuery}{searchValue}";
            var webRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            webRequest.ContentType = ConstantHelpers.WebRequest.SearchEngine.CONTENT_TYPE;
            webRequest.UserAgent = ConstantHelpers.WebRequest.SearchEngine.USER_AGENT;
            webRequest.Timeout = ConstantHelpers.WebRequest.SearchEngine.TIMEOUT;

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
