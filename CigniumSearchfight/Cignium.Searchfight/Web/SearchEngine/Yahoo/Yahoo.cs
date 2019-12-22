using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model.Web;
using Cignium.Searchfight.Web.SearchEngine.Base;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Web.SearchEngine.Yahoo
{
    public class Yahoo : BaseSearchEngine, IYahoo
    {
        public Yahoo()
        {
            request = new Request()
            {
                Title = "Yahoo"
            };
        }

        public void LoadResultNumber()
        {
            switch (ConstantHelpers.General.PREFERRED_OPERATION)
            {
                default:
                    LoadResultNumber(ConstantHelpers.Http.Yahoo.Response.ResultNumber.REGEX_PATTERN, ConstantHelpers.Http.Yahoo.Response.ResultNumber.SPLIT_SEPARATOR);

                    break;
            }
        }

        public async Task LoadResponseBySearchValue(string searchValue)
        {
            currentResult.Text = searchValue;

            switch (ConstantHelpers.General.PREFERRED_OPERATION)
            {
                default:
                    await LoadHttpResponseBySearchValue(searchValue);

                    break;
            }
        }

        public async Task LoadHttpResponseBySearchValue(string searchValue)
        {
            var requestUri = new Uri(ConstantHelpers.Http.Yahoo.Url.SearchEngine.SEARCH);
            requestUri = requestUri.AddQuery("q", searchValue);

            await LoadHttpResponse(requestUri);
        }
    }
}
