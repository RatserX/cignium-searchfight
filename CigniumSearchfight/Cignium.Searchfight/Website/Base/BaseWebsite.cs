using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cignium.Searchfight.Website.Base
{
    public class BaseWebsite : IBaseWebsite
    {
        protected Core.Model.Website website;

        public BaseWebsite()
        {

        }

        public string GetWebsiteTitle()
        {
            return website.Title;
        }

        public string GetWebsiteUrl()
        {
            return $"{website.Url.Host}{website.Url.PathQuery}";
        }
    }
}
