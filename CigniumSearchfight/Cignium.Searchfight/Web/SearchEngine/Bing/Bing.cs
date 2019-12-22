using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model.Web;
using Cignium.Searchfight.Web.SearchEngine.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Web.SearchEngine.Bing
{
    public class Bing : BaseSearchEngine, IBing
    {
        public Bing()
        {
            request = new Request()
            {
                Title = "Bing"
            };
        }

        public void LoadResultNumber()
        {
            switch (ConstantHelpers.General.PREFERRED_OPERATION)
            {
                case ConstantHelpers.Operation.API:
                    LoadResultNumber(ConstantHelpers.Api.Bing.Response.ResultNumber.REGEX_PATTERN, ConstantHelpers.Api.Bing.Response.ResultNumber.SPLIT_SEPARATOR);

                    break;
                default:
                    LoadResultNumber(ConstantHelpers.Http.Bing.Response.ResultNumber.REGEX_PATTERN, ConstantHelpers.Http.Bing.Response.ResultNumber.SPLIT_SEPARATOR);

                    break;
            }
        }

        public async Task LoadResponseBySearchValue(string searchValue)
        {
            currentResult.Text = searchValue;

            switch (ConstantHelpers.General.PREFERRED_OPERATION)
            {
                case ConstantHelpers.Operation.API:
                    await LoadApiResponseBySearchValue(searchValue);

                    break;
                default:
                    await LoadHttpResponseBySearchValue(searchValue);

                    break;
            }
        }

        public async Task LoadApiResponseBySearchValue(string searchValue)
        {
            var requestUri = new Uri(ConstantHelpers.Api.Bing.Url.BingSearchV7.SEARCH);
            requestUri = requestUri.AddQuery("q", searchValue);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            httpWebRequest.ContentType = ConstantHelpers.WebRequest.Api.CONTENT_TYPE;
            httpWebRequest.Headers["Ocp-Apim-Trace"] = "true";
            httpWebRequest.Headers["Ocp-Apim-Subscription-Key"] = ConstantHelpers.Api.Bing.Request.V7.KEY1;
            httpWebRequest.Headers["UserAgent"] = ConstantHelpers.WebRequest.USER_AGENT;
            httpWebRequest.Timeout = ConstantHelpers.WebRequest.TIMEOUT;

            await LoadResponse(httpWebRequest);
        }

        public async Task LoadHttpResponseBySearchValue(string searchValue)
        {
            var requestUri = new Uri(ConstantHelpers.Http.Bing.Url.SearchEngine.SEARCH);
            requestUri = requestUri.AddQuery("q", searchValue);

            await LoadHttpResponse(requestUri);
        }
    }
}
