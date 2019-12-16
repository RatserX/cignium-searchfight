using Cignium.Searchfight.Core.Extension;
using Cignium.Searchfight.Core.Helper;
using Cignium.Searchfight.Core.Model;
using Cignium.Searchfight.Website.SearchEngine.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Searchfight.Website.SearchEngine.Yahoo
{
    public class Yahoo : BaseSearchEngine, IYahoo
    {
        public Yahoo()
        {
            request = new Request()
            {
                Title = ConstantHelpers.Website.Yahoo.TITLE,
                Url = new Url()
                {
                    Host = ConstantHelpers.Website.Yahoo.Url.SearchEngine.HOST,
                    PathQuery = ConstantHelpers.Website.Yahoo.Url.SearchEngine.PATH_QUERY
                }
            };
        }

        public Yahoo(Request request)
        {
            this.request = request;
        }
    }
}
