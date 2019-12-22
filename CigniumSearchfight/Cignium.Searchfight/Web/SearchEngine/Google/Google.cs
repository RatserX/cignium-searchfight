using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model.Web;
using Cignium.Searchfight.Web.SearchEngine.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Web.SearchEngine.Google
{
    public class Google : BaseSearchEngine, IGoogle
    {
        public Google()
        {
            request = new Request()
            {
                Title = "Google"
            };
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
            var requestUri = new Uri($"{ConstantHelpers.Api.Google.Url.CustomSearch.CUSTOMSEARCH}{ConstantHelpers.Api.Google.Request.KEY}&cx=017576662512468239146:omuauf_lfve");
            requestUri = requestUri.AddQuery("key", searchValue);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
            httpWebRequest.ContentType = ConstantHelpers.WebRequest.Api.CONTENT_TYPE;
            httpWebRequest.Timeout = ConstantHelpers.WebRequest.TIMEOUT;

            await LoadResponse(httpWebRequest);
        }

        public async Task LoadHttpResponseBySearchValue(string searchValue)
        {
            var requestUri = new Uri(ConstantHelpers.Http.Google.Url.SearchEngine.SEARCH);
            requestUri = requestUri.AddQuery("q", searchValue);

            await LoadHttpResponse(requestUri);
        }

        public void LoadResultNumber()
        {
            switch (ConstantHelpers.General.PREFERRED_OPERATION)
            {
                case ConstantHelpers.Operation.API:
                    LoadResultNumber(ConstantHelpers.Api.Google.Response.ResultNumber.REGEX_PATTERN, ConstantHelpers.Api.Google.Response.ResultNumber.SPLIT_SEPARATOR);

                    break;
                default:
                    LoadResultNumber(ConstantHelpers.Http.Google.Response.ResultNumber.REGEX_PATTERN, ConstantHelpers.Http.Google.Response.ResultNumber.SPLIT_SEPARATOR);

                    break;
            }
        }

        public void LoadResultTime()
        {
            switch (ConstantHelpers.General.PREFERRED_OPERATION)
            {
                default:
                    LoadResultTime(ConstantHelpers.Http.Google.Response.ResultTime.REGEX_PATTERN, ConstantHelpers.Http.Google.Response.ResultTime.SPLIT_SEPARATOR);

                    break;
            }
        }
    }
}
